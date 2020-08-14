using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cookie : MonoBehaviour
{
    //　円が大きくなるスピード
    float speed=1;


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener (CookieClick);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(gameObject.activeSelf){

            ControllCircle();
        }
        */
        
    }
    /*
    void ControllCircle(){

        GameObject circle = gameObject.transform.GetChild(0).gameObject;
        circle.transform.localScale += new Vector3 (speed,speed,1); 
    }
    */

    public void CookieClick(){
        this.gameObject.SetActive(false);
        Debug.Log("wa-iwa-iwa---i");
    }

    public void ChangeCookieImage(int kindnum){

        string ImagePass="";

        switch (kindnum)
        {
            case 1:
                ImagePass = "Pictures/cookie1";
                break;

            case 2:
                ImagePass = "Pictures/cookie2";
                break;
            
            case 3:
                ImagePass = "Pictures/cookie3";
                break;

            case 4:
                ImagePass = "Pictures/cookie4";
                break;
            
        }

        //Image image = GetComponent<Image>();

        Sprite sprite = Resources.Load<Sprite>(ImagePass);
        this.GetComponent<Image>().sprite = sprite;
        //GetComponent<Image>();
    }

    public float GetSpeed(){
        return speed;
    }
}

