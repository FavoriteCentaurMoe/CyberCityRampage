using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    public LocalControllersManager lcm;
    public PlayerController player1;
    public PlayerController player2;
    public PlayerController player3;
    public PlayerController player4;
    public Slider player1Health;
    public Slider player1Resource;
    public Slider player2Health;
    public Slider player2Resource;
    //public Slider player1Health;
    //public Slider player1Resource;
    //public Slider player1Health;
    //public Slider player1Resource;

    // Use this for initialization
    void Start () {
        lcm = FindObjectOfType<LocalControllersManager>();
        if(lcm.plr1Set)
        {
            player1Health.gameObject.SetActive(true);
            if (lcm.player1Character == "Warrior")
            {
                player1Resource.gameObject.SetActive(true);
            }
        }
        if (lcm.plr2Set)
        {
            player2Health.gameObject.SetActive(true);
            if (lcm.player2Character == "Warrior")
            {
                player2Resource.gameObject.SetActive(true);
            }
        }
        //if (lcm.plr3Set)
        //{
        //    player3Health.gameObject.SetActive(true);
        //}
        //if (lcm.plr4Set)
        //{
        //    player4Health.gameObject.SetActive(true);
        //}


    }
	
	// Update is called once per frame
	void Update () {
        /*
         * all of this should be handled differently when a player chooses a character.  this is just for testing purposes
         */
        if (lcm.plr1Set)
        {
            player1Health.maxValue = player1.maxHealth;
            player1Health.value = player1.currentHealth;
            if (player1.GetComponent<WarriorController>() != null)
            {
                WarriorController warrior = player1.GetComponent<WarriorController>();
                player1Resource.maxValue = warrior.maxRage;
                player1Resource.value = warrior.currentRage;
            }
        }
        if (lcm.plr2Set)
        {
            player2Health.maxValue = player2.maxHealth;
            player2Health.value = player2.currentHealth;
            if (player2.GetComponent<WarriorController>() != null)
            {
                WarriorController warrior = player2.GetComponent<WarriorController>();
                player2Resource.maxValue = warrior.maxRage;
                player2Resource.value = warrior.currentRage;
            }
        }

    }
}
