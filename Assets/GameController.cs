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
    public Slider healthBar;

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
        if(healthBar.value<50){
            tellingMomStory();
        }
        if(playerDie){
            theAM.ChangeSong(playerDieMusic);
            story.text="Bless humans, long may live them";
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
        if(numberOfAwared>0&&numberOfAwared<=2){
            story.text="Humans are the real aliens, they invaded my home! Earth!";
        }
        if(numberOfAwared>2&&numberOfAwared<=4){
            story.text="My home was Earth once called paradise before they came";
        }
        if(numberOfAwared>4&&numberOfAwared<=6){
            story.text="They eliminated my species. I am the only one left.";
        }
        if(numberOfAwared>6&&numberOfAwared<=8){
            story.text="They corrupted the history, calling themselves aboriginals.";
        }
        if(numberOfAwared>8){
            story.text="They want to kill me, yet call me the monster!";
        }
    }
    public void SetAwaredCountText(){
        if(! isSecondAware&&!playerDie){
            AwaredCountText.text = "Humans Alerted: "+numberOfAwared.ToString();
        }  
        else{
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
        story.text="I MUST RUN TO THE TEMPLE TO BURRY MOTHER'S ASHES!";
    }

    public void tellingMomStory(){
        story.text="They slaughtered mother, worshiping her burnings as holy ashes!";
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
