using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
   
    private GameObject[] Cookies;

    [SerializeField]
	public GameObject Cookie;
    

    // Start is called before the first frame update
    void Start()
    {
        CookiesInitiallize();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CookiesInitiallize(){

        Cookies = new GameObject[1024];
        for (int i=0; i < GameInfo.COOKIE_NUM; i++){
            int kindnum = Random.Range(1, 4);
            Cookies[i] =  Instantiate (Cookie,new Vector3(0.0f,0.0f,0.0f),Quaternion.identity) as GameObject;

            Cookies[i].GetComponent<cookie>().ChangeCookieImage(kindnum);

        }
    }

    void CookiesControll(){
        GameObject circle = gameObject.transform.GetChild(0).gameObject;
        //circle.transform.localScale += new Vector3 (speed,speed,1); 
    }
}
