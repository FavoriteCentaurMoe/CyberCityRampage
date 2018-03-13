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

    public Sprite warrior;
    public Sprite mage;
    public Sprite sharpshooter;
    public Sprite medic;

    public Image player1Icon;
    public Slider player1Health;
    public Slider player1Resource;
    public Image player1ResourceImage;

    public Image player2Icon;
    public Slider player2Health;
    public Slider player2Resource;
    public Image player2ResourceImage;

    public Image player3Icon;
    public Slider player3Health;
    public Slider player3Resource;
    public Image player3ResourceImage;

    public Image player4Icon;
    public Slider player4Health;
    public Slider player4Resource;
    public Image player4ResourceImage;

    // Use this for initialization
    void Start () {
        lcm = FindObjectOfType<LocalControllersManager>();
        if(lcm.plr1Set)
        {
            player1Icon.gameObject.SetActive(true);
            player1Health.gameObject.SetActive(true);
            player1Resource.gameObject.SetActive(true);
            if(lcm.player1Character == "Warrior")
            {
                player1ResourceImage.color = Color.red;
                player1Icon.sprite = warrior;
            }
            else if (lcm.player1Character == "Medic")
            {
                player1ResourceImage.color = Color.cyan;
                player1Icon.sprite = medic;
            }
            else if (lcm.player1Character == "SharpShooter")
            {
                player1ResourceImage.color = Color.cyan;

                player1Icon.sprite = sharpshooter;
            }
            else
            {
                player1ResourceImage.color = Color.cyan;
                player1Icon.sprite = mage;
            }
        }
        if (lcm.plr2Set)
        {
            player2Icon.gameObject.SetActive(true);
            player2Health.gameObject.SetActive(true);
            player2Resource.gameObject.SetActive(true);
            if (lcm.player2Character == "Warrior")
            {
                player2ResourceImage.color = Color.red;
                player2Icon.sprite = warrior;
            }
            else if (lcm.player2Character == "Medic")
            {
                player2ResourceImage.color = Color.cyan;
                player2Icon.sprite = medic;
            }
            else if (lcm.player2Character == "SharpShooter")
            {
                player2ResourceImage.color = Color.cyan;

                player2Icon.sprite = sharpshooter;
            }
            else
            {
                player2ResourceImage.color = Color.cyan;
                player2Icon.sprite = mage;
            }
        }
        if (lcm.plr3Set)
        {
            player3Icon.gameObject.SetActive(true);
            player3Health.gameObject.SetActive(true);
            player3Resource.gameObject.SetActive(true);
            if (lcm.player3Character == "Warrior")
            {
                player3ResourceImage.color = Color.red;
                player3Icon.sprite = warrior;
            }
            else if (lcm.player3Character == "Medic")
            {
                player3ResourceImage.color = Color.cyan;
                player3Icon.sprite = medic;
            }
            else if (lcm.player3Character == "SharpShooter")
            {
                player3ResourceImage.color = Color.cyan;

                player3Icon.sprite = sharpshooter;
            }
            else
            {
                player3ResourceImage.color = Color.cyan;
                player3Icon.sprite = mage;
            }
        }
        if (lcm.plr4Set)
        {
            player4Icon.gameObject.SetActive(true);
            player4Health.gameObject.SetActive(true);
            player4Resource.gameObject.SetActive(true);
            if (lcm.player4Character == "Warrior")
            {
                player4ResourceImage.color = Color.red;
                player4Icon.sprite = warrior;
            }
            else if (lcm.player4Character == "Medic")
            {
                player4ResourceImage.color = Color.cyan;
                player4Icon.sprite = medic;
            }
            else if (lcm.player4Character == "SharpShooter")
            {
                player4ResourceImage.color = Color.cyan;

                player4Icon.sprite = sharpshooter;
            }
            else
            {
                player4ResourceImage.color = Color.cyan;
                player4Icon.sprite = mage;
            }
        }


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
            else if(player1.GetComponent<SharpShooterController>() != null)
            {
                SharpShooterController sharpshooter = player1.GetComponent<SharpShooterController>();
                player1Resource.maxValue = sharpshooter.maxEnergy;
                player1Resource.value = sharpshooter.currentEnergy;
            }
            else if (player1.GetComponent<MedicPlayerController>() != null)
            {
                MedicPlayerController medic = player1.GetComponent<MedicPlayerController>();
                player1Resource.maxValue = medic.maxEnergy;
                player1Resource.value = medic.currentEnergy;
            }
            else
            {
                MageController mage = player1.GetComponent<MageController>();
                player1Resource.maxValue = mage.maxEnergy;
                player1Resource.value = mage.currentEnergy;
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
            else if (player2.GetComponent<SharpShooterController>() != null)
            {
                SharpShooterController sharpshooter = player2.GetComponent<SharpShooterController>();
                player2Resource.maxValue = sharpshooter.maxEnergy;
                player2Resource.value = sharpshooter.currentEnergy;
            }
            else if (player2.GetComponent<MedicPlayerController>() != null)
            {
                MedicPlayerController medic = player2.GetComponent<MedicPlayerController>();
                player2Resource.maxValue = medic.maxEnergy;
                player2Resource.value = medic.currentEnergy;
            }
            else
            {
                MageController mage = player2.GetComponent<MageController>();
                player2Resource.maxValue = mage.maxEnergy;
                player2Resource.value = mage.currentEnergy;
            }
        }
        if (lcm.plr3Set)
        {
            player3Health.maxValue = player3.maxHealth;
            player3Health.value = player3.currentHealth;
            if (player3.GetComponent<WarriorController>() != null)
            {
                WarriorController warrior = player3.GetComponent<WarriorController>();
                player3Resource.maxValue = warrior.maxRage;
                player3Resource.value = warrior.currentRage;
            }
            else if (player3.GetComponent<SharpShooterController>() != null)
            {
                SharpShooterController sharpshooter = player3.GetComponent<SharpShooterController>();
                player3Resource.maxValue = sharpshooter.maxEnergy;
                player3Resource.value = sharpshooter.currentEnergy;
            }
            else if (player3.GetComponent<MedicPlayerController>() != null)
            {
                MedicPlayerController medic = player3.GetComponent<MedicPlayerController>();
                player3Resource.maxValue = medic.maxEnergy;
                player3Resource.value = medic.currentEnergy;
            }
            else
            {
                MageController mage = player3.GetComponent<MageController>();
                player3Resource.maxValue = mage.maxEnergy;
                player3Resource.value = mage.currentEnergy;
            }
        }
        if (lcm.plr4Set)
        {
            player4Health.maxValue = player4.maxHealth;
            player4Health.value = player4.currentHealth;
            if (player4.GetComponent<WarriorController>() != null)
            {
                WarriorController warrior = player4.GetComponent<WarriorController>();
                player4Resource.maxValue = warrior.maxRage;
                player4Resource.value = warrior.currentRage;
            }
            else if (player4.GetComponent<SharpShooterController>() != null)
            {
                SharpShooterController sharpshooter = player4.GetComponent<SharpShooterController>();
                player4Resource.maxValue = sharpshooter.maxEnergy;
                player4Resource.value = sharpshooter.currentEnergy;
            }
            else if (player4.GetComponent<MedicPlayerController>() != null)
            {
                MedicPlayerController medic = player4.GetComponent<MedicPlayerController>();
                player4Resource.maxValue = medic.maxEnergy;
                player4Resource.value = medic.currentEnergy;
            }
            else
            {
                MageController mage = player4.GetComponent<MageController>();
                player4Resource.maxValue = mage.maxEnergy;
                player4Resource.value = mage.currentEnergy;
            }
        }

    }
}
