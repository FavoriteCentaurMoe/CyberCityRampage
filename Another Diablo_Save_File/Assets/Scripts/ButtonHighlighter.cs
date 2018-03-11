
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonHighlighter : MonoBehaviour
{
    public GameObject[] buttons;
    public int buttonCounter = 0;

    //public GameObject defaultButton;
    public EventSystem es;
    private void Start()
    {
        es = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        if (buttons[buttonCounter] != null)
        {
            es.SetSelectedGameObject(buttons[buttonCounter]);
        }
    }

    private void Update()
    {
        Debug.Log(Input.GetAxis("C1 Left Button"));
    }
}
/*
public class ButtonHighlighter : MonoBehaviour
{
    private Button previousButton;
    [SerializeField] private float scaleAmount = 1.4f;
    [SerializeField] private GameObject defaultButton;

    private void Awake()
    {
        if (defaultButton != null)
        {
            EventSystem.current.SetSelectedGameObject(defaultButton);
        }
    }
*/
    /*
    void Start()
    {
        if (defaultButton != null)
        {
            EventSystem.current.SetSelectedGameObject(defaultButton);
        }
    }
    */
    /*
    void Update()
    {
        var selectedObj = EventSystem.current.currentSelectedGameObject;

        if (selectedObj == null) return;
        var selectedAsButton = selectedObj.GetComponent<Button>();
        if (selectedAsButton != null && selectedAsButton != previousButton)
        {
            if (selectedAsButton.transform.name != "PauseButton")
                HighlightButton(selectedAsButton);
        }

        if (previousButton != null && previousButton != selectedAsButton)
        {
            UnHighlightButton(previousButton);
        }
        previousButton = selectedAsButton;
    }
    void OnDisable()
    {
        if (previousButton != null) UnHighlightButton(previousButton);
    }


    void HighlightButton(Button butt)
    {
        //if (SettingsManager.Instance.UsingTouchControls) return;
        butt.transform.localScale = new Vector3(scaleAmount, scaleAmount, scaleAmount);
    }

    void UnHighlightButton(Button butt)
    {
        //if (SettingsManager.Instance.UsingTouchControls) return;
        butt.transform.localScale = new Vector3(1, 1, 1);
    }
    */

//}

