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

    public bool check1 = true;
    public bool check2 = true;
    public bool check3 = true;
    public bool check4 = true;


    public GameObject death_menu;

    public Transform player1spawn;
    public Transform player2spawn;
    public Transform player3spawn;
    public Transform player4spawn;

    public UIController ui_controller;

    public CameraFollower main_cam;

    public int init_num_targets = 0;
    public bool AllSet = false;

    // Use this for initialization
    private void Awake()
    {
        lcm = FindObjectOfType<LocalControllersManager>();
    }
    void Start () {
        check1 = true;
        check2 = true;
        check3 = true;
        check4 = true;
        init_num_targets = 0;
    
        //ui_controller.lcm = lcm;
        if(lcm.plr1Set)
        {
            Debug.Log("player 1 set");
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
        main_cam.targets.Add(player1.transform);
        init_num_targets += 1;
        }
        
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
        main_cam.targets.Add(player2.transform);
        init_num_targets += 1;
        }
        
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
        main_cam.targets.Add(player3.transform);
        init_num_targets += 1;
        }
        
        // add in the 4th
        if (lcm.plr4Set)
        {
            if (lcm.player4Character == "Warrior")
            {
                player4 = Instantiate(Warrior, player4spawn);
                player4.GetComponent<PlayerMovement>().controller_num = lcm.player4;
                ui_controller.player4 = player4.GetComponent<PlayerController>();
            }
            else if (lcm.player4Character == "SharpShooter")
            {
                player4 = Instantiate(SharpShooter, player4spawn) as GameObject;
                player4.GetComponent<PlayerMovement>().controller_num = lcm.player4;
                ui_controller.player4 = player4.GetComponent<PlayerController>();
            }
            else if (lcm.player4Character == "Medic")
            {
                dog_character_4 = Instantiate(Dog, player4spawn);
                player4 = Instantiate(Medic, player4spawn);
                foreach (Transform child in player4.transform)
                {
                    if (child.gameObject.tag == "Dog Spot")
                    {
                        dog_character_4.GetComponent<DogScript>().owner = child.gameObject;
                    }
                }
                player4.GetComponent<MedicPlayerController>().dog = dog_character_4.GetComponent<DogScript>();
                player4.GetComponent<PlayerMovement>().controller_num = lcm.player4;
                ui_controller.player4 = player4.GetComponent<PlayerController>();
            }
            else
            {
                player4 = Instantiate(Mage, player4spawn);
                player4.GetComponent<PlayerMovement>().controller_num = lcm.player4;
                ui_controller.player4 = player4.GetComponent<PlayerController>();
            }
         main_cam.targets.Add(player4.transform);
         init_num_targets += 1;
        }
        Debug.Log("aboout to be all set ");
        AllSet = true;
        
    }
	
	// Update is called once per frame
	void Update () {
        
        if (init_num_targets >= 1 && check1 && main_cam.targets.Contains(player1.transform))// player still alive?
        {
            // could put the ability cooldowns here
            if (player1.GetComponent<PlayerController>().currentHealth <= 0) // died just now?
            {
                check1 = false;
                main_cam.targets.Remove(player1.transform); // remove from cam
                if (player1.GetComponent<MedicPlayerController>() != null) // if medic
                {
                    Destroy(dog_character_1); // dog needs to leave as well
                }
                Destroy(player1.gameObject);
                
            }
        }

        if (init_num_targets >= 2 && check2 && main_cam.targets.Contains(player2.transform))
        {
            if (player2.GetComponent<PlayerController>().currentHealth <= 0)
            {
                check2 = false;
                main_cam.targets.Remove(player2.transform);
                if (player2.GetComponent<MedicPlayerController>() != null)
                {

                    Destroy(dog_character_2);
                }
                Destroy(player2.gameObject);
                
            }
        }

        Debug.Log("Not Getting to player 3");

        if (init_num_targets >= 3 && check3 && main_cam.targets.Contains(player3.transform))
        {
            if (player3.GetComponent<PlayerController>().currentHealth <= 0)
            {
                check3 = false;
                main_cam.targets.Remove(player3.transform);
                if (player3.GetComponent<MedicPlayerController>() != null)
                {
                    Destroy(dog_character_3);
                }
                Destroy(player3.gameObject);
               
            }
        }

        Debug.Log("Reading Through Player 3");

        if (init_num_targets >= 4 && check4 && main_cam.targets.Contains(player4.transform))
        {
            if (player4.GetComponent<PlayerController>().currentHealth <= 0)
            {
                check4 = false;
                
                main_cam.targets.Remove(player4.transform);
                if (player4.GetComponent<MedicPlayerController>() != null)
                {
                    Destroy(dog_character_4);
                }
                Destroy(player4.gameObject);
               
            }
        }

        

    }

    private void LateUpdate()
    {
        AllDead();
    }

    void AllDead()
    {
        //Debug.Log("here working");
        if(main_cam.targets.Count <= 0)
        {
            Debug.Log("count is 0");
            Time.timeScale = 0;
            death_menu.gameObject.SetActive(true);
            AllSet = false;
        }
    }
}
