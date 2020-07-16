using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;


public class SaveToFile : MonoBehaviour
{
    public PlayerController player;
    private int fileCount = 1;

    //end game menu
   //public GameObject savePanel;
    // Start is called before the first frame update
    void Start()
    {
       // savePanel.SetActive(false); 
    }
    private void Update()
    {
 
    }
    public void Load()
    {
        //yay. streamwriters he he i wanna diiiiiiiie
        StreamReader sr=null;
        try
        {
            sr = new StreamReader("PlayerProfile" + fileCount);
    
            float tempHealth = float.Parse(sr.ReadLine());
            float tempSanity= float.Parse(sr.ReadLine());
            float tempSoul = float.Parse(sr.ReadLine());
            int tempMB = int.Parse(sr.ReadLine());
            int tempHellMonies = int.Parse(sr.ReadLine());

            player.InitializePlayerStats(tempHealth, tempSanity, tempSoul, tempHellMonies, tempMB);
            

        }
        catch
        {
            player.InitializePlayerStats(0, 0, 0, 0, 0);
        }
        finally
        {
            if (sr != null)
            {
                sr.Close();
            }
        }
        
    }
    public void NewSave()
    {
        fileCount++;
        if (fileCount > 3)
        {
            fileCount = 1;
        }
        StreamWriter sw = new StreamWriter("PlayerProfile"+fileCount);
        sw.WriteLine(player.pHeath);
        sw.WriteLine(player.pSanity);
        sw.WriteLine(player.pSoul);
        sw.WriteLine(player.pMB);
        sw.WriteLine(player.pHellMonies);
        
        sw.Close();


    }
    public void OverrideSave()
    {
        StreamWriter sw = new StreamWriter("PlayerProfile" + fileCount);
        sw.WriteLine(player.pHeath);
        sw.WriteLine(player.pSanity);
        sw.WriteLine(player.pSoul);
        sw.WriteLine(player.pMB);
        sw.WriteLine(player.pHellMonies);
        sw.Close();
    }
}
