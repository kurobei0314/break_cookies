using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cookie : MonoBehaviour
{
    //　円が大きくなるスピード
    int speed=1;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.activeSelf){

            ControllCircle();
        }
        
    }

    void ControllCircle(){

        GameObject circle = gameObject.transform.GetChild(0).gameObject;
        circle.transform.localScale += new Vector3 (speed,speed,1); 
    }
}

