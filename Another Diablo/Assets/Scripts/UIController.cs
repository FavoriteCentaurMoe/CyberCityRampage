using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    public WarriorController warrior_controller;
    public Slider player1Health;
    public Slider player1Resource;

	// Use this for initialization
	void Start () {


    }
	
	// Update is called once per frame
	void Update () {
        /*
         * all of this should be handled differently when a player chooses a character.  this is just for testing purposes
         */
        player1Health.maxValue = warrior_controller.maxHealth;
        player1Resource.maxValue = warrior_controller.maxRage;
        player1Health.value = warrior_controller.currentHealth;
        player1Resource.value = warrior_controller.currentRage;
		
	}
}
