using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class playerhealth : MonoBehaviour
{
    // Start is called before the first frame update
    public float curhealth;
    public float maxhealth;

    public Slider healthBar;
    public GameObject player; 
    private Animator anim;
    public GameObject controller;

    public Text healthcounter;
    public bool isDead = false;
    void Start()
    {
        curhealth=maxhealth;
        healthBar.value=curhealth;
        healthBar.maxValue=maxhealth;
        anim=GetComponent<Animator>();

        controller=GameObject.FindWithTag("GameController");
        UpdateHealthCount();
    }

    // Update is called once per frame
    void Update()
    {
        //detect if player is hit 
        float hit =anim.GetFloat("isBeaten");
        if (hit >0){
            //Debug.Log("hit");
       
        	anim.SetFloat("isBeaten",hit);
        }
        if(curhealth<1&&!isDead){
            //GetComponent<CapsuleCollider>().direction=2;
        	anim.SetBool("death",true);
            //GameObject.Destroy(gameObject);
            controller.GetComponent<GameController>().playerDied();
            isDead=true;

            //collider.direction=2;
        }
        /*if(Input.GetKeyUp(KeyCode.Return)){
        	SendDamage(Random.Range(5,10));
        }*/

        
    }

    //detect collision from enemy 
    public void OnCollisionEnter(Collision other){
        
        if(other.gameObject.tag =="Enemy"&&controller.GetComponent<GameController>().secondAware()){       
            //Debug.Log("coll");
            SendDamage(Random.Range(5,10));
            
        }

    }

    //the player is health is damaged when he is hit, value of health bar also decreased 
    public void SendDamage(float damageValue)
    {
        curhealth-=damageValue;
    	healthBar.value=curhealth;
        //Debug.Log(curhealth);
    	anim.SetFloat("isBeaten",1);
        UpdateHealthCount();
    }

    void Dead()
    {
        curhealth = 0;
        isDead = true;
        healthBar.value = 0;
        //UpdateHealthCount();
        Debug.Log("Player is Dead");

    }

    void UpdateHealthCount()
    {
        if (curhealth < 0)
        {
            Dead();
            healthcounter.text = curhealth.ToString();

        }

        else
        {
            healthcounter.text = curhealth.ToString();
        }
    }
}
