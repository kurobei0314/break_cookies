using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public GameObject CookiesParent;

    //クッキーの状態を管理する
    private GameObject[] Cookies;

    //クッキーのprehad
    [SerializeField]
	public GameObject Cookie;

    //見えてるクッキーのインデントを示す
    int DisplayIndent=0;
    

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
            //float x_pos = Random.Range(-400.0f, 400.0f);
            //float y_pos= Random.Range(-300.0f, 300.0f);

            float x_pos = Random.Range(-350.0f, 350.0f);
            float y_pos= Random.Range(-250.0f, 250.0f);

            Cookies[i] =  Instantiate (Cookie,new Vector3(0.0f,0.0f,0.0f),Quaternion.identity) as GameObject;

            Cookies[i].GetComponent<cookie>().ChangeCookieImage(kindnum);

            Cookies[i].transform.parent = CookiesParent.transform;
            Cookies[i].transform.localScale = new Vector3(1.0f,1.0f,1.0f);
            Cookies[i].transform.localPosition = new Vector3(x_pos,y_pos,1.0f);

            //Cookies[i].SetActive(true);
            Cookies[i].SetActive(false);

        }
    }

    void CookiesControll(){
        
        for (int i=0; i < DisplayIndent; i++){

            if(Cookies[i].activeSelf){
                GameObject circle = Cookies[i].transform.Find("circle").gameObject;
                float speed = Cookies[i].GetComponent<cookie>().GetSpeed();
                circle.transform.localScale += new Vector3 (speed,speed,1); 
            }
        }
    }
}
