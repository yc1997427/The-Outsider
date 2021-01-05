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

    public AudioClip playerDieMusic;

    public AudioClip secondAwareMusic;
    public AudioClip encounterEnemyMusic;

    private bool encounterEnemyMusicPlayed=false;
    private bool secondAwareMusicPlayed=false;

    private AudioManager theAM;

    public Text story;

    void Start()
    {
       theAM = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {   
        if(numberOfAwared>0){
            if(!encounterEnemyMusicPlayed){
                theAM.ChangeSong(encounterEnemyMusic);
            }
            encounterEnemyMusicPlayed=true;

        }


        if(playerDie){
            theAM.ChangeSong(playerDieMusic);
        }
        if(isSecondAware){
            if(!secondAwareMusicPlayed){
                theAM.ChangeSong(secondAwareMusic);
            }
            secondAwareMusicPlayed=true;         
        }
        SetAwaredCountText();
    }
    public int Awared(){

    	return numberOfAwared;
    }
    public void detected(){
    	numberOfAwared+=1;
        tellingHumanStory();
    }

    public void tellingHumanStory(){
        if(numberOfAwared>0&&numberOfAwared<=4){
            story.text="They humans were aliens, invaded my home-earth";
        }
        if(numberOfAwared>4&&numberOfAwared<=6){
            story.text="They elinimated our specie, only myself left";
        }
        if(numberOfAwared>6&&numberOfAwared<=9){
            story.text="They perverted history, calling themselves Earthlings";
        }
        if(numberOfAwared>9){
            story.text="They call me monster, calling me invader";
        }
    }

    public void SetAwaredCountText(){
        if(!isSecondAware&&!playerDie){
            AwaredCountText.text = "Awaredhumans: "+numberOfAwared.ToString();
        }  
        if(isSecondAware&&!playerDie){
            AwaredCountText.text ="They are coming!";
        }
        if(playerDie){
            AwaredCountText.text ="Game Over";
        }        
    }

    public void OnSecondAware(){
        if(!isSecondAware){
            battellingStory();
        }
        isSecondAware=true;
    }
    public void battellingStory(){
        story.text="I don't have to kill them myself, they are killing each other";
    }

    public void tellingMomStory(){
        story.text="They slaughtered mom, worshiping her burnings as holy ashes";
    }



    public bool secondAware(){
        return isSecondAware;
    }
    public void playerDied(){
        playerDie=true;
    }

    public bool playerDeath(){
        return playerDie; 
    }

}
