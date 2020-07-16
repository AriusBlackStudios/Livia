using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Endings : MonoBehaviour
{
    // Start is called before the first frame update
    public Text Credits;

    // Update is called once per frame
    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Morgue")
        {
            Credits.text = "After Fighting her way through the dock in the underworld" +
                "\n Livia Collected enough strength to be revived and Continue here quest for answers and revenge on earth." +
                "\n Having little memory of her time there, she will no-doubtably return";
        }
        if (SceneManager.GetActiveScene().name == "MentalScape")
        {
            Credits.text = "Blinded by rage and bloodlust, Livia spiralled into madness." +
                "\n Reaching a dark abyss that no one but she can pull herself out of." +
                "Does Her story End here, or is there more to it?";
        }
        if (SceneManager.GetActiveScene().name == "TheBlackness")
        {
            Credits.text = "Consumed by fire, Livia's soul had been erased from reality," +
                "\n Her name a faint memory, she hadn't even the luxury of hell." +
                "\n Her soul was ripped from all realms and destroyed, lost for all time.";
        }
    }
   

    public void Mainmenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
       
    
}
