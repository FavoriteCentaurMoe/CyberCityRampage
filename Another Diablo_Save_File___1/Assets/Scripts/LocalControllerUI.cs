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

    public Text player1;
    public Text player2;
    public Text player3;
    public Text player4;



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(lcm.plr1Set)
        {
            player1choice.gameObject.SetActive(true);
            player1.gameObject.SetActive(true);
            if (lcm.player1Character == "Warrior")
            {
                player1choice.sprite = warrior;
                player1.text = "Player 1\nWarrior";
            }
            else if (lcm.player1Character == "SharpShooter")
            {
                player1choice.sprite = sharpshooter;
                player1.text = "Player 1\nRanger";
            }
            else if (lcm.player1Character == "Medic")
            {
                player1choice.sprite = medic;
                player1.text = "Player 1\nMedic";
            }
            else
            {
                player1choice.sprite = mage;
                player1.text = "Player 1\nMage";
            }
        }

        if (lcm.plr2Set)
        {
            player2choice.gameObject.SetActive(true);
            player2.gameObject.SetActive(true);
            if (lcm.player2Character == "Warrior")
            {
                player2choice.sprite = warrior;
                player2.text = "Player 2\nWarrior";
            }
            else if (lcm.player2Character == "SharpShooter")
            {
                player2choice.sprite = sharpshooter;
                player2.text = "Player 2\nRanger";
            }
            else if (lcm.player2Character == "Medic")
            {
                player2choice.sprite = medic;
                player2.text = "Player 2\nMedic";
            }
            else
            {
                player2choice.sprite = mage;
                player2.text = "Player 2\nMage";
            }
        }

        if (lcm.plr3Set)
        {
            player3choice.gameObject.SetActive(true);
            player3.gameObject.SetActive(true);
            if (lcm.player3Character == "Warrior")
            {
                player3choice.sprite = warrior;
                player3.text = "Player 3\nWarrior";
            }
            else if (lcm.player3Character == "SharpShooter")
            {
                player3choice.sprite = sharpshooter;
                player3.text = "Player 3\nRanger";
            }
            else if (lcm.player3Character == "Medic")
            {
                player3choice.sprite = medic;
                player3.text = "Player 3\nMedic";
            }
            else
            {
                player3choice.sprite = mage;
                player3.text = "Player 3\nMage";
            }
        }
        if (lcm.plr4Set)
        {
            player4choice.gameObject.SetActive(true);
            player4.gameObject.SetActive(true);
            if (lcm.player4Character == "Warrior")
            {
                player4choice.sprite = warrior;
                player4.text = "Player 4\nWarrior";
            }
            else if (lcm.player4Character == "SharpShooter")
            {
                player4choice.sprite = sharpshooter;
                player4.text = "Player 4\nRanger";
            }
            else if (lcm.player4Character == "Medic")
            {
                player4choice.sprite = medic;
                player4.text = "Player 4\nMedic";
            }
            else
            {
                player4choice.sprite = mage;
                player4.text = "Player 4\nMage";
            }
        }
    }
}
