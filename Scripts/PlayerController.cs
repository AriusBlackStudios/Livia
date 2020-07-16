using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    //player stats
    int speed=10;
    public bool isSoulAlive, isHealthAlive, isSanityLow;
    float Soul,Health,Sanity,Booster;
    public float pHeath { get{ return Health;}}
    public float pSoul { get { return Soul; } }
    public float pSanity { get { return Sanity; } }
    public float pBooster { get { return Booster; } }
    public float BloodBonusPerk = 1;

    public float blackmagic, firemagic, bloodmagic;
    public SaveToFile save;

    //counters and currencies
    int musicBoxes,souls;
    public int pMB { get { return musicBoxes; } }
    public int pHellMonies { get { return souls; } }

    public Text playerMemo;
    public Slider health, soul, sanity,booster;
    public GameObject instructions;

    //magic system stuff
    public Transform Cannon;
    public string[] magicSystem;
    public string magic;
    public int magicIndex;
    public float cTime, mTime;

    void Start()
    {
        //filling magic system
        magicSystem = new string[3];
        magicSystem[0] = "BlackMagic";
        magicSystem[1] = "FireMagic";
        magicSystem[2] = "BloodMagic";
        magicIndex = 0;
        magic = magicSystem[magicIndex];
        mTime = 1;

        Health = 0;
        Sanity = 500;
        Soul = 1000;
        instructions.SetActive(false);

        blackmagic = -10;
        bloodmagic = -10;
        firemagic = -10;

    }


    // Update is called once per frame
    void Update()
    {
        //meters
       // Debug.Log(sanity);
        health.value = Health;
        soul.value = Soul;
        sanity.value = Sanity;
        booster.value = Booster;
        
        cTime += Time.deltaTime;
        if (isSoulAlive || isHealthAlive || !isSanityLow)
        {
            Move();
            if (SceneManager.GetActiveScene().name == "UnderWorld")
            {
                if (health.value >= health.maxValue)
                {
                    save.OverrideSave();
                    SceneManager.LoadScene("Morgue");
                }

                if (sanity.value >=sanity.maxValue )
                {
                    save.OverrideSave();
                    SceneManager.LoadScene("MentalScape");
                    Debug.Log("if i felt like it, youd be catatonic, but aint no body got time for that");
                }
                if (soul.value <= 0)
                {
                    save.OverrideSave();
                    SceneManager.LoadScene("TheBlackNess");
                }
            }
        }
        else
        {
            if (soul.value <= soul.minValue)
            {
                SceneManager.LoadScene("TheEmpty");
            }
        }
    }
    public void Move()
    {
        if (Input.GetKey(KeyCode.KeypadEnter))
        {
            transform.Translate(transform.up * Time.deltaTime * speed, Space.World);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(transform.forward * Time.deltaTime * speed, Space.World);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(-transform.forward * Time.deltaTime * speed, Space.World);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Rotate(Vector3.down * 1.2f);
            this.transform.Rotate(Vector3.forward * 0f);
            this.transform.Rotate(Vector3.back * 0f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Rotate(Vector3.up * 1.2f);
            this.transform.Rotate(Vector3.forward * 0f);
            this.transform.Rotate(Vector3.back * 0f);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("wheel");
                Instantiate(Resources.Load(magic), Cannon.position, Cannon.rotation);

            Debug.Log("Instantiated");
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Debug.Log("LeftClick");
            if (magicIndex < 2)
            {
                magicIndex++;
                magic = magicSystem[magicIndex];
                Debug.Log("cycled");
            }
            else
            {
                magicIndex = 0;
                magic = magicSystem[magicIndex];
            }

        }
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            if (instructions.activeSelf == true)
            {
                instructions.SetActive(false);
            }
            else
            {
                instructions.SetActive(true);
            }
        }

    }
    public void ChangeSoul(float change)
    {
        //if (isSoulAlive)
       // {
            if (change >= 0) //potions
            {
                Debug.Log("Soul damage restored" + change);
                playerMemo.text = "soul damage restored " + change;
                Soul += change;
            }

            else if (change < 0) //attacks
            {
                Debug.Log("Soul damage taken" + change);
                Soul += change;
                playerMemo.text = "soul damage taken " + change;
                if (Soul <= 0)
                {
                    isSoulAlive = false;
                    //Load oblivion endng
                }
            }
       // }

    }

    public void MusicBoxes(int box)
    {
        //note going to be used in the demo... probably?
        if (box < 0)
        {
            Debug.Log("you've Lost a memory fragment");
            musicBoxes = +box;
            playerMemo.text = "you've Lost " + -1 * box + " Memory Fragments";
        }
        if (box > 0)
        {
            Debug.Log("you've Gained a memory fragment");
            musicBoxes = +box;
            playerMemo.text = "you've Gained " + box + " Memory Fragments";
        }
    }

    public void ChangeHealth(float change)
    {
        //if (isHealthAlive)
        //{
            if (change >= 0)
            {
                change *= BloodBonusPerk;
                Debug.Log("Physical damage restored" + change);
                playerMemo.text = "Physical damage restored " + change;
                Health += change;
            }

            else if (change < 0)
            {
                Debug.Log("Physical damage taken" + change);
                Health += change;
                playerMemo.text = "Physical damage taken " + change;
                if (Health <= 0)
                {
                    isHealthAlive = false;
                    //load hell
                }
            }
        //}

    }
    public void ChangeBoost(float change)
    {


        if (change >= 0)
        {
            Debug.Log("Surplus Blood Gained" + change);
            Health += change;
        }

        else if (change < 0)
        {
            Debug.Log("Physical damage taken" + change);
            Health += change;
            playerMemo.text = "Physical damage taken " + change;
            if (Health <= 0)
            {
                isHealthAlive = false;
                //load hell
            }
        }
    }

    public void ChangeSanity(float change)
    {
        //not used in demo, used to send player to mental scape when they die in full game
      //  if (!isSanityLow)
      //  {
            if (change < 0)//negATIVE, BECAUSE the bar represents instability
            {
                Debug.Log("Psychological damage restored" + change);
                playerMemo.text = "Psychological damage restored " + change;
                Sanity += change;
                if (Sanity <= 200)
                {
                    isSanityLow = true;
                    //load previos scene, max health at 50 percent, speed divided by some number, make all npc's agro, 
                    //maybe just make a method called Paranoia and call that...
                }
            }

            else if (change >= 0)
            {
                Debug.Log("Psychological damage taken" + change);
                Sanity += change;
                playerMemo.text = "Psychological damage taken " + change;

            }
      //  }

    }

    public void InitializePlayerStats(float playerhealth, float playersanity,float playersoul,int hellmonies, int mb)
    {
        Health = playerhealth;
        Sanity = playersanity;
        Soul = playersoul;
        souls = hellmonies;
        musicBoxes = mb;
    }

}
