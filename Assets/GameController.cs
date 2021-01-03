using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    public  int numberOfAwared=0;
    public Text AwaredCountText;

    public bool isSecondAware=false;

    public bool playerDie=false;

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        SetAwaredCountText();
    }
    public int Awared(){
    	return numberOfAwared;
    }
    public void detected(){
    	numberOfAwared+=1;
    }
    public void SetAwaredCountText(){
        if(! isSecondAware&&!playerDie){
            AwaredCountText.text = "Awaredhumans: "+numberOfAwared.ToString();
        }  
        else{
            AwaredCountText.text ="They are coming!";
        }
        if(playerDie){
            AwaredCountText.text ="Game Over";
        }

        
    }
    public void OnSecondAware(){
        isSecondAware=true;
    }
    public bool secondAware(){
        return isSecondAware;
    }
}
