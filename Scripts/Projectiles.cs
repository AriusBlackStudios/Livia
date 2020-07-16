using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    public bool isBlood, isFire, isBlack;
    // on self inflicted damage: rock paper sizors
    //blood draws from health, affects soul, 
    //fire draws from soul, affects sanity,
    //black draws from sanity, affects health
    public int speed;
    public float timer;
    public PlayerController player;
    public float negativeDamage;
    // Start is called before the first frame update
    public void shoot()
    {
        transform.Translate(transform.forward * Time.deltaTime * speed, Space.World);
      timer -= Time.deltaTime;
        if (timer < 0)
        {
            DestroyObject(this.gameObject,timer);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("triggered");
        if (other.tag == "Player")
        {
            if (isBlood)
            {
                player.SendMessage("ChangeSoul", player.bloodmagic);
            }
            if (isBlack)
            {
                player.SendMessage("ChangeHealth", player.blackmagic);
            }
            if (isFire)
            {
                player.SendMessage("ChangeSanity", player.firemagic);
            }

            DestroyObject(this.gameObject);
        }
        else if (other.tag == "Enemy")
        {

            other.SendMessage("takeDamage", negativeDamage);
            other.SendMessage("Agro", false);
            DestroyObject(this.gameObject);

        }
    }

    private void Update()
    {
        shoot();
    }

}
