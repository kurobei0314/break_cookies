using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public GameObject CookiesParent;

    [SerializeField]
    Text ScoreText;

    //クッキーの状態を管理する
    private GameObject[] Cookies;

    //クッキーのprehad
    [SerializeField]
	public GameObject Cookie;

    //見えてるクッキーのインデントを示す
    int DisplayIndent=0;

    //時間を表示するText型の変数
    public Text timeText;

    public GameObject CountCookie;

    //カウント時間を表示するText型の変数
    private Text CountTimeText;
    private GameObject CountCookieImage;

    private float GameTimes = GameInfo.GAME_TIME;
    private float CountTimes = 4;

    //ゲームの状況を管理する
    public enum GameState{
        COUNT,
        MAIN,
        GAMEOVER
    }
    public GameState currentGameState;

    // Start is called before the first frame update
    void Start()
    {
        SetcurrentGameState(GameState.COUNT);
        AudioManager.Instance.PlayBGM("kuturogi");
        CookiesInitiallize();
        ScoreManager.instance.score = GameInfo.COOKIE_NUM;
        //SetcurrentGameState(GameState.MAIN);

        CountTimeText = CountCookie.transform.Find("CountText").gameObject.GetComponent<Text>();
        CountCookieImage = CountCookie.transform.Find("Image").gameObject;
        timeText.text  = "もうすぐ";
        ScoreText.text = "はじまるよー！";
    }

    // Update is called once per frame
    void Update()
    {
    
        if(currentGameState == GameState.MAIN){
            CookiesControll();
            GameTimeCounter();
            ScoreText.text = "てもち"+((int)ScoreManager.instance.score).ToString() + "枚";
        }
        else if (currentGameState == GameState.GAMEOVER){
            AudioManager.Instance.StopBGM();
            SceneManager.LoadScene("Result");
        }
        else if(currentGameState == GameState.COUNT){

            CountCookieImage.transform.Rotate(0.0f,0.0f,0.2f);

            CountTimes=TimeCounter(CountTimes);
            CountTimeText.text = ((int)CountTimes).ToString();
            if(CountTimes <= 0){
                SetcurrentGameState(GameState.MAIN);
                CountCookie.SetActive(false);
            }
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
            float y_pos = Random.Range(-250.0f, 250.0f);

            float scale = Random.Range(GameInfo.MIN_COOKIE_SCALE, GameInfo.MAX_COOKIE_SCALE);

            Cookies[i] =  Instantiate(Cookie,new Vector3(0.0f,0.0f,0.0f),Quaternion.identity) as GameObject;

            Cookies[i].GetComponent<cookie>().ChangeCookieImage(kindnum);

            float speed = Random.Range(GameInfo.MIN_SPEED, GameInfo.MAX_SPEED);
            Cookies[i].GetComponent<cookie>().SetSpeed(speed);

            Cookies[i].transform.SetParent(CookiesParent.transform);
            Cookies[i].transform.localScale = new Vector3(scale,scale,1.0f);
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

        int itimes = (int)GameTimes;
        int ActiveTime = (int)(GameInfo.GAME_TIME / GameInfo.COOKIE_NUM);
        
        if( DisplayIndent == 0 || (int)( (GameInfo.GAME_TIME - itimes) / (ActiveTime*DisplayIndent)) == 1 ){
            if(DisplayIndent != GameInfo.COOKIE_NUM){

                Cookies[DisplayIndent].SetActive(true);
                DisplayIndent++;
            }
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

    void GameTimeCounter(){

        //時間をカウントする
        GameTimes = TimeCounter(GameTimes);

        //時間を表示する
        timeText.text = "あと"+((int)GameTimes).ToString() + "秒";

        if(GameTimes < 0) SetcurrentGameState(GameState.GAMEOVER);
    }

    float TimeCounter(float time){

        time -= Time.deltaTime;
        return time;
    }
}
