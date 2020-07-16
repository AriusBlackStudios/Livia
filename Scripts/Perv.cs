using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Perv : MonoBehaviour
{
    public GameObject Store;
    public PlayerController player;
    public Text dialogBox;
    int questionCounter=0;

    public bool bm1, bm2, bm3, fm1, fm2, fm3, blm1, blm2, blm3,bb1,bb2,bb3;
    public void BoostBlackMagicDamage()
    {

        if (!bm1)
        {
            if (player.health.value > 50)
            {
                dialogBox.text = "Eccelent ... That will cost you though.\n 50 points of your life force";
                player.SendMessage("ChangeHealth", -50);
                player.blackmagic = -50;
            }
            else { dialogBox.text = " you dont have the nessisary sacrifice to buy this upgrade right now, Livia."; }
        }
        else if  (bm1 && !bm2)
        {
            if (player.health.value > 100)
            {
                dialogBox.text = "Eccelent ... That will cost you though.\n 100 points of your life force";
                player.SendMessage("ChangeHealth", -50);
                player.blackmagic = -100;
            }
            else { dialogBox.text = " you dont have the nessisary sacrifice to buy this upgrade right now, Livia."; }
        }
        else if (bm1 && bm2&& !bm3)
        {
            if (player.health.value > 300)
            {
                dialogBox.text = "Eccelent ... That will cost you though.\n 300 points of your life force";
                player.SendMessage("ChangeHealth", -50);
                player.blackmagic = -300;
            }
            else { dialogBox.text = " you dont have the nessisary sacrifice to buy this upgrade right now, Livia."; }
        }
        else
        {
            dialogBox.text = "You've upgrade your Black Magic as high as I can make it for now.";
        }

    }
    public void BoostBloodMagicDamage()
    {

        if (!blm1)
        {
            if (player.health.value > 50)
            {
                dialogBox.text = "Eccelent ... That will cost you though.\n 50 points of your life force";
                player.SendMessage("ChangeHealth", -50);
                player.bloodmagic = -50;
            }
            else { dialogBox.text = " you dont have the nessisary sacrifice to buy this upgrade right now, Livia."; }
        }
        else if (blm1 && !blm2)
        {
            if (player.health.value > 100)
            {
                dialogBox.text = "Eccelent ... That will cost you though.\n 100 points of your life force";
                player.SendMessage("ChangeHealth", -50);
                player.bloodmagic = -100;
            }
            else { dialogBox.text = " you dont have the nessisary sacrifice to buy this upgrade right now, Livia."; }
        }
        else if (blm1 && blm2 && !blm3)
        {
            if (player.health.value > 300)
            {
                dialogBox.text = "Eccelent ... That will cost you though.\n 300 points of your life force";
                player.SendMessage("ChangeHealth", -50);
                player.bloodmagic = -300;
            }
            else { dialogBox.text = " you dont have the nessisary sacrifice to buy this upgrade right now, Livia."; }
        }
        else
        {
            dialogBox.text = "You've upgrade your Blood Magic as high as I can make it for now.";
        }

    }
    public void BoostFireMagicDamage()
    {

        if (!fm1)
        {
            if (player.health.value > 50)
            {
                dialogBox.text = "Eccelent ... That will cost you though.\n 50 points of your life force";
                player.SendMessage("ChangeHealth", -50);
                player.firemagic = -50;
            }
            else { dialogBox.text = " you dont have the nessisary sacrifice to buy this upgrade right now, Livia."; }
        }
        else if (fm1 && !fm2)
        {
            if (player.health.value > 100)
            {
                dialogBox.text = "Eccelent ... That will cost you though.\n 100 points of your life force";
                player.SendMessage("ChangeHealth", -50);
                player.firemagic = -100;
            }
            else { dialogBox.text = " you dont have the nessisary sacrifice to buy this upgrade right now, Livia."; }
        }
        else if (fm1 && fm2 && !fm3)
        {
            if (player.health.value > 300)
            {
                dialogBox.text = "Eccelent ... That will cost you though.\n 300 points of your life force";
                player.SendMessage("ChangeHealth", -50);
                player.firemagic = -300;
            }
            else { dialogBox.text = " you dont have the nessisary sacrifice to buy this upgrade right now, Livia."; }
        }
        else
        {
            dialogBox.text = "You've upgrade your Blood Magic as high as I can make it for now.";
        }

    }

    private void OnMouseOver()
    {
        dialogBox.text = "Hello again, back so soon? How can I help you darling?";
    }
    private void OnMouseDown()
    {
        dialogBox.text = "here to chat? \n or Use your lifeforce to buy Power here before you fill it up all the way";
        if (Store.activeSelf==false)
        {
            Store.SetActive(true);
        }
        else
        {
            Store.SetActive(false);
            dialogBox.text = "";
        }
    }

    private void Start()
    {
        Store.SetActive(false);
    }

    public void WhyAmIHere()
    {
        dialogBox.text = "Because you got yourself killed again, silly child." +
            "\n This is Charon's Dock, He's the ferryman of the underworld human souls come here to wait for him";
    }

    public void whatarethosemonsters()
    {
        if (questionCounter == 0)
        {
            dialogBox.text = "Why Dont You ask them?";
            questionCounter++;
        }
        if (questionCounter == 1)
        {
            dialogBox.text = "some of them were here before you .... some of them were here becuase of you.";
            questionCounter++;
        }
        if (questionCounter == 2)
        {
            dialogBox.text = "Livia, don't worry about them, they're already dead. If You're so concerned, why dont you go clean up?";
            questionCounter = 0;

        }
    }

    public void howDoILeave()
    {
        dialogBox.text = "To Come back to the world of the living, you must replenish your lifeforce with the souls of the dead." +
            "\n to press on deeper into the realm of the dead, you must sacrifice the souls of the living";

    }

    public void BloodBonus()
    {
        if (!bb1)
        {
            if (player.health.value > 50)
            {
                dialogBox.text = "Eccelent ... That will cost you though.\n 50 points of your life force";
                player.SendMessage("ChangeHealth", -50);
                player.BloodBonusPerk = 2;
            }
            else { dialogBox.text = " you dont have the nessisary sacrifice to buy this upgrade right now, Livia."; }
        }
        else if (bb1 && !bb2)
        {
            if (player.health.value > 100)
            {
                dialogBox.text = "Eccelent ... That will cost you though.\n 100 points of your life force";
                player.SendMessage("ChangeHealth", -50);
                player.BloodBonusPerk= 5;
            }
            else { dialogBox.text = " you dont have the nessisary sacrifice to buy this upgrade right now, Livia."; }
        }
        else if (bb1 && bb2 && !bb3)
        {
            if (player.health.value > 300)
            {
                dialogBox.text = "Eccelent ... That will cost you though.\n 300 points of your life force";
                player.SendMessage("ChangeHealth", -50);
                player.BloodBonusPerk= 10;
            }
            else { dialogBox.text = " you dont have the nessisary sacrifice to buy this upgrade right now, Livia."; }
        }
        else
        {
            dialogBox.text = "You've upgrade your Black Magic as high as I can make it for now.";
        }
    }
}
