using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalControllerUI : MonoBehaviour {
    public LocalControllersManager lcm;
    public Image player1choice;
    public Image player2choice;
    public Image player3choice;
    public Image player4choice;
    public Sprite warrior;
    public Sprite sharpshooter;
    public Sprite dog;
    public Sprite medic;
    public Sprite mage;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(lcm.plr1Set)
        {
            player1choice.gameObject.SetActive(true);
            if (lcm.player1Character == "Warrior")
            {
                player1choice.sprite = warrior;
            }
            else if (lcm.player1Character == "SharpShooter")
            {
                player1choice.sprite = sharpshooter;
            }
            else if (lcm.player1Character == "Medic")
            {
                player1choice.sprite = medic;
            }
            else
            {
                player1choice.sprite = mage;
            }
        }

        if (lcm.plr2Set)
        {
            player2choice.gameObject.SetActive(true);
            if (lcm.player2Character == "Warrior")
            {
                player2choice.sprite = warrior;
            }
            else if (lcm.player2Character == "SharpShooter")
            {
                player2choice.sprite = sharpshooter;
            }
            else if (lcm.player2Character == "Medic")
            {
                player2choice.sprite = medic;
            }
            else
            {
                player2choice.sprite = mage;
            }
        }

        if (lcm.plr3Set)
        {
            player3choice.gameObject.SetActive(true);
            if (lcm.player3Character == "Warrior")
            {
                player3choice.sprite = warrior;
            }
            else if (lcm.player3Character == "SharpShooter")
            {
                player3choice.sprite = sharpshooter;
            }
            else if (lcm.player3Character == "Medic")
            {
                player3choice.sprite = medic;
            }
            else
            {
                player3choice.sprite = mage;
            }
        }
        if (lcm.plr4Set)
        {
            player4choice.gameObject.SetActive(true);
            if (lcm.player4Character == "Warrior")
            {
                player4choice.sprite = warrior;
            }
            else if (lcm.player4Character == "SharpShooter")
            {
                player4choice.sprite = sharpshooter;
            }
            else if (lcm.player4Character == "Medic")
            {
                player4choice.sprite = medic;
            }
            else
            {
                player4choice.sprite = mage;
            }
        }
    }
}
