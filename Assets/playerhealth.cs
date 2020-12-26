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
        	hit-=Time.deltaTime*3;
        }
        if(curhealth<1){
        	anim.SetBool("death",true);
        }
        if(Input.GetKeyUp(KeyCode.Space)){
        	SendDamage(Random.Range(10,20));
        }
    }

    public void SendDamage(float damageValue){
    	curhealth-=damageValue;
    	healthBar.value=curhealth;
    }
}
