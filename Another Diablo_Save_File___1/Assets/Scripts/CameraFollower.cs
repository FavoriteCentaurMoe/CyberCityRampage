using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFollower : MonoBehaviour
{
    public List<Transform> targets;

    public Vector3 offset;

    public float smoothTime;

    private Vector3 velocity;

    public float minZoom = 40f;
    public float maxZoom = 10f;
    public float zoomLimiter = 50f;

    private Camera cam;


    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    private void LateUpdate()
    {
        if (SceneManager.GetActiveScene().name == "Boss")
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -556, -556), Mathf.Clamp(transform.position.y, 37, 37), transform.position.z);
        }
        else if (SceneManager.GetActiveScene().name == "Marlonthings")
        {
            if (targets.Count == 0)
                return;
            Move();
            Zoom();
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -642, -229), Mathf.Clamp(transform.position.y, -255, 30), transform.position.z);
        }
        else
        {
            if (targets.Count == 0)
            {
                return;
            }

            Move();
            Zoom();
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -617, -202), Mathf.Clamp(transform.position.y, -230, 45), transform.position.z);
        }
    }

    void Zoom()
    {
        float newZoom = Mathf.Lerp(maxZoom, minZoom, GetGreatestDistance() / zoomLimiter);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);
    }

    void Move()
    {
        Vector3 centerPoint = GetCenterPoint();

        Vector3 newPosition = centerPoint + offset;

        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }

    float GetGreatestDistance()
    {
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }
        return bounds.size.x;
    }

    Vector3 GetCenterPoint()
    {
        if (targets.Count == 1)
        {
            return targets[0].position;
        }
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }
        return bounds.center;
    }
}
