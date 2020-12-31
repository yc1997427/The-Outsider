using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class playerhealth : MonoBehaviour
{
  
  /**
  // Start is called before the first frame update
    public float curhealth;
    public float maxhealth;

    public Slider healthBar;
    public GameObject player; 
    private Animator anim;
    void Start()
    {
        curhealth=maxhealth;
        healthBar.value=curhealth;
        healthBar.maxValue=maxhealth;
        anim=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float hit =anim.GetFloat("hit");
        if (hit >0){
       
        	anim.SetFloat("hit",hit);
        }
        if(curhealth<1){
            GetComponent<CapsuleCollider>().direction=2;
        	anim.SetBool("death",true);

            
      
            //collider.direction=2;
        }
        if(Input.GetKeyUp(KeyCode.Return)){
        	SendDamage(Random.Range(10,20));
        }

        
    }

    public void OnCollisionEnter(Collision other){
        
        if(other.gameObject.tag =="Enemy"){       
            //Debug.Log("coll");
            SendDamage(Random.Range(10,20));
            
        }

    }

    public void SendDamage(float damageValue){
        
    	curhealth-=damageValue;
    	healthBar.value=curhealth;
        Debug.Log(curhealth);
    	anim.SetFloat("hit",1);
    } 
    
    */
    public static playerhealth singleton;
    public float currentHealth;
    public float maxHealth = 100f;
    public bool isDead = false;


    public Slider healthBar;
    public Text healthcounter;
    public GameObject player;
    private Animator anim;


    void Start()
    {
        singleton = this;
        currentHealth = maxHealth;
        healthBar.value = currentHealth;
        healthBar.maxValue = maxHealth;
        anim = GetComponent<Animator>();
        UpdateHealthCounter();
    }


    public void DamagePlayer(float damage)
    {

        if (currentHealth > 0)
        {
            if (damage >= currentHealth)
            {
                Dead();

            }
            else
            {
                currentHealth -= damage;
                // healthBar.value = currentHealth;
                healthBar.value -= damage;
            }

            UpdateHealthCounter();
        }


    }

    void Dead()
    {
        currentHealth = 0;
        isDead = true;
        healthBar.value = 0;
        UpdateHealthCounter();
        Debug.Log("Player is Dead");
    }

    void UpdateHealthCounter()
    {
        healthcounter.text = currentHealth.ToString();
    }
}
