using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{

    //nave mesh
    public NavMeshAgent agent;
    public Transform mouth,playerPos;
    public Transform[] waypoints;

   
    public float Health, HealthDrop,Damage;
    public bool isAlive,isFriendly,level1,level2,level3;
    public PlayerController player;//to access player methods

    public Text dialogbox;
    public Slider enemyHealth;

    public int count = 0;
    public int annoyance = -1;
    public string[] sentences;

    private float cTime = 0; // control spitting rate
    private float mTime = 1;

    private void OnMouseDown()
    {
        annoyance++;
        Dialog();
    }
    public void Dialog()
    {
        if (annoyance < sentences.Length)
        {
            // speech = sentences[annoyance];
            // dialogbox.text = "we the people in order to form a more perfect union .....";
            dialogbox.text = "" + sentences[annoyance];
        }
        if (annoyance >= sentences.Length)
        {
            Debug.Log("agro");
            dialogbox.text = "";
            isFriendly = false;
            //activate growl audio?
        }
    }

    void Start()
    {
      // player = FindObjectOfType<PlayerController>();
        enemyHealth.maxValue = Health;
        isAlive = true;
        isFriendly = true;
    }
    void Update()
    {
        enemyHealth.value = Health;
        if (isAlive)
        {
            Move();
            if (!isFriendly)
            {
                Attack();
            }
        }
        else
        {
            //this.gameObject.SetActive(false);
            //ItemDrop();

        }
    }

    public void Attack()
    {
        //spit, so eject projectiles for now
        int distance = (int)this.transform.position.magnitude - (int)playerPos.position.magnitude;
        if (distance < 5)
        {
            cTime += Time.deltaTime;
            if (cTime > mTime)
            {
                if (level2)
                { 
                Instantiate(Resources.Load("Acid"), mouth.position, mouth.rotation);
                }

                if (level1)
                {
                    player.SendMessage("ChangeSoul", -10);
                    player.SendMessage("ChangeSanity", 10);
                }
                if (level3)
                {
                    player.SendMessage("ChangeSoul", -10);
                    player.SendMessage("ChangeSanity", 10);
                    Instantiate(Resources.Load("Acid"), mouth.position, mouth.rotation);
                }

                cTime = 0;
            }
        }

    }
    public void Agro(bool change)
    {
        isFriendly = change;
    }
    public void Move()
    {
        int distance = (int)this.transform.position.magnitude - (int)playerPos.position.magnitude;
        if (distance < 10&& !isFriendly)
        {
            agent.SetDestination(playerPos.position);
            Attack();
        }
        else if (waypoints.Length > 0)
        {
            agent.SetDestination(waypoints[count].position);
            if ((int)this.transform.position.magnitude == (int)waypoints[count].position.magnitude)
            {
                count++;
                if (count == waypoints.Length) { count = 0; }
            }
        }
    }
    public void ItemDrop()
    {
        if (player.health.value < player.health.maxValue)
        {
            player.SendMessage("ChangeHealth", HealthDrop);
        }
        else
        {
            player.SendMessage("ChangeBoost", HealthDrop);
        }
    }
    public void takeDamage(int damage)
    {
        Health += damage;
        if (Health <= 0)
        {
            isAlive = false;
            Destroy(this.gameObject);
            ItemDrop();
        }
    }
}
