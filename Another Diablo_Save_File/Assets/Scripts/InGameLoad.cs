using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameLoad : MonoBehaviour {
    public LocalControllersManager lcm;
    public GameObject Warrior;
    public GameObject Medic;
    public GameObject Dog;
    public GameObject SharpShooter;
    public GameObject Mage;
    public GameObject player1;
    public GameObject dog_character_1;
    public GameObject player2;
    public GameObject dog_character_2;
    public GameObject player3;
    public GameObject dog_character_3;
    public GameObject player4;
    public GameObject dog_character_4;

    public Transform player1spawn;
    public Transform player2spawn;
    public Transform player3spawn;
    public Transform player4spawn;

    public UIController ui_controller;

    public CameraFollower main_cam;

	// Use this for initialization
	void Start () {
        lcm = FindObjectOfType<LocalControllersManager>();
        //ui_controller.lcm = lcm;
        if(lcm.plr1Set)
        {
            //Debug.Log(lcm.player1);
            //Debug.Log(lcm.player1Character);
            if (lcm.player1Character == "Warrior")
            {
                player1 = Instantiate(Warrior, player1spawn);
                player1.GetComponent<PlayerMovement>().controller_num = lcm.player1;
                ui_controller.player1 = player1.GetComponent<PlayerController>();
            }
            else if(lcm.player1Character == "SharpShooter")
            {
                player1 = Instantiate(SharpShooter, player1spawn);
                player1.GetComponent<PlayerMovement>().controller_num = lcm.player1;
                ui_controller.player1 = player1.GetComponent<PlayerController>();
            }
            else if (lcm.player1Character == "Medic")
            {
                dog_character_1 = Instantiate(Dog, player1spawn);
                player1 = Instantiate(Medic, player1spawn);
                foreach(Transform child in player1.transform)
                {
                    if(child.gameObject.tag == "Dog Spot")
                    {
                        dog_character_1.GetComponent<DogScript>().owner = child.gameObject;
                    }
                }
                player1.GetComponent<MedicPlayerController>().dog = dog_character_1.GetComponent<DogScript>();
                player1.GetComponent<PlayerMovement>().controller_num = lcm.player1;
                ui_controller.player1 = player1.GetComponent<PlayerController>();
            }
            else
            {
                player1 = Instantiate(Mage, player1spawn);
                player1.GetComponent<PlayerMovement>().controller_num = lcm.player1;
                ui_controller.player1 = player1.GetComponent<PlayerController>();
            }

        }
        main_cam.targets.Add(player1.transform);
        if(lcm.plr2Set)
        {
            Debug.Log(lcm.player2);
            Debug.Log(lcm.player2Character);
            if (lcm.player2Character == "Warrior")
            {
                player2 = Instantiate(Warrior, player2spawn);
                player2.GetComponent<PlayerMovement>().controller_num = lcm.player2;
                ui_controller.player2 = player2.GetComponent<PlayerController>();
            }
            else if (lcm.player2Character == "SharpShooter")
            {
                player2 = Instantiate(SharpShooter, player2spawn) as GameObject;
                player2.GetComponent<PlayerMovement>().controller_num = lcm.player2;
                ui_controller.player2 = player2.GetComponent<PlayerController>();
            }
            else if (lcm.player2Character == "Medic")
            {
                dog_character_2 = Instantiate(Dog, player2spawn);
                player2 = Instantiate(Medic, player2spawn);
                foreach (Transform child in player2.transform)
                {
                    if (child.gameObject.tag == "Dog Spot")
                    {
                        dog_character_2.GetComponent<DogScript>().owner = child.gameObject;
                    }
                }
                player2.GetComponent<MedicPlayerController>().dog = dog_character_2.GetComponent<DogScript>();
                player2.GetComponent<PlayerMovement>().controller_num = lcm.player2;
                ui_controller.player2 = player2.GetComponent<PlayerController>();
            }
            else
            {
                player2 = Instantiate(Mage, player2spawn);
                player2.GetComponent<PlayerMovement>().controller_num = lcm.player2;
                ui_controller.player2 = player2.GetComponent<PlayerController>();
            }
        }
        main_cam.targets.Add(player2.transform);
        if (lcm.plr3Set)
        {
            if (lcm.player3Character == "Warrior")
            {
                player3 = Instantiate(Warrior, player3spawn);
                player3.GetComponent<PlayerMovement>().controller_num = lcm.player3;
                ui_controller.player3 = player3.GetComponent<PlayerController>();
            }
            else if (lcm.player3Character == "SharpShooter")
            {
                player3 = Instantiate(SharpShooter, player3spawn) as GameObject;
                player3.GetComponent<PlayerMovement>().controller_num = lcm.player3;
                ui_controller.player3 = player3.GetComponent<PlayerController>();
            }
            else if (lcm.player3Character == "Medic")
            {
                dog_character_3 = Instantiate(Dog, player3spawn);
                player3 = Instantiate(Medic, player3spawn);
                foreach (Transform child in player3.transform)
                {
                    if (child.gameObject.tag == "Dog Spot")
                    {
                        dog_character_3.GetComponent<DogScript>().owner = child.gameObject;
                    }
                }
                player3.GetComponent<MedicPlayerController>().dog = dog_character_3.GetComponent<DogScript>();
                player3.GetComponent<PlayerMovement>().controller_num = lcm.player3;
                ui_controller.player3 = player3.GetComponent<PlayerController>();
            }
            else
            {
                player3 = Instantiate(Mage, player3spawn);
                player3.GetComponent<PlayerMovement>().controller_num = lcm.player3;
                ui_controller.player3 = player3.GetComponent<PlayerController>();
            }
        }
        main_cam.targets.Add(player3.transform);
        // add in the 4th
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
