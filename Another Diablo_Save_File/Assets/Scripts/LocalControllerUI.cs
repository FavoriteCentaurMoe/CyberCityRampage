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
        }

        if (lcm.plr2Set)
        {
            player2choice.gameObject.SetActive(true);
            if (lcm.player2Character == "Warrior")
            {
                player2choice.sprite = warrior;
            }
            else if (lcm.player1Character == "SharpShooter")
            {
                player2choice.sprite = sharpshooter;
            }
        }
    }
}
