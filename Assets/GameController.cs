using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    public  int numberOfAwared=0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int Awared(){
    	return numberOfAwared;
    }
    public void detected(){
    	numberOfAwared+=1;
    }
}
