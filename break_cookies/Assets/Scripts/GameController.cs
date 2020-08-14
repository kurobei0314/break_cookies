using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    //時間を表示するText型の変数
    public Text timeText;

    private float times = GameInfo.GAME_TIME;

    //ゲームの状況を管理する
    public enum GameState{
        PREPARE,
        MAIN,
        GAMEOVER
    }
    public GameState currentGameState;

    // Start is called before the first frame update
    void Start()
    {
        SetcurrentGameState(GameState.PREPARE);
        CookiesInitiallize();
        ScoreManager.instance.score = 0;
        SetcurrentGameState(GameState.MAIN);
    }

    // Update is called once per frame
    void Update()
    {
        if(currentGameState == GameState.MAIN){
            CookiesControll();
            TimeCounter();
        }
    }

    void SetcurrentGameState(GameState state){
        currentGameState = state;
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

            float speed = Random.Range(GameInfo.MIN_SPEED, GameInfo.MAX_SPEED);
            Cookies[i].GetComponent<cookie>().SetSpeed(speed);

            Cookies[i].transform.parent = CookiesParent.transform;
            Cookies[i].transform.localScale = new Vector3(1.0f,1.0f,1.0f);
            Cookies[i].transform.localPosition = new Vector3(x_pos,y_pos,1.0f);

            //Cookies[i].SetActive(true);
            Cookies[i].SetActive(false);
        }
    }

    void CookiesControll(){
        
        CookiesActive();
        CookiesCircle();
    }

    //一定時間経過するごとにクッキーを表示させる
    void CookiesActive(){

        int itimes = (int)times;
        int ActiveTime = (int)(GameInfo.GAME_TIME / GameInfo.COOKIE_NUM);
        
        if( DisplayIndent == 0 || (int)( (GameInfo.GAME_TIME - itimes) / (ActiveTime*DisplayIndent)) == 1 ){

            Cookies[DisplayIndent].SetActive(true);
            DisplayIndent++;
        }
    }

    //クッキーの円関係の関数
    void CookiesCircle(){

        for (int i=0; i < DisplayIndent; i++){

            if(Cookies[i].activeSelf){
                GameObject circle = Cookies[i].transform.Find("circle").gameObject;
                float speed = Cookies[i].GetComponent<cookie>().GetSpeed();
                circle.transform.localScale += new Vector3 (speed,speed,1); 

                if (circle.transform.localScale.x > GameInfo.MAX_CSIZE){
                    Cookies[i].SetActive(false);
                }
                
            }
        }
    }

    void TimeCounter(){

         //時間をカウントする
        times -= Time.deltaTime;

        //時間を表示する
        timeText.text = ((int)times).ToString() + "秒";

        if(times > GameInfo.GAME_TIME) SetcurrentGameState(GameState.GAMEOVER);
    }
}
