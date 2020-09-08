using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultController : MonoBehaviour
{

    [SerializeField]
    GameObject Text;

    [SerializeField]
    GameObject button_title;

    [SerializeField]
    GameObject button_ranking;

    GameObject Text1;
    GameObject Text2;


    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.PlayBGM("04_karuiasidoride");
        TextInitiallize();
        TextContent();
        button_title.SetActive(false);
        button_ranking.SetActive(false);
        button_title.GetComponent<Button>().onClick.AddListener (titleClick);
        button_ranking.GetComponent<Button>().onClick.AddListener(rankingClick);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("AnimationResult"); 
    }

    void TextInitiallize(){

        Text1 = Text.transform.Find("Text1").gameObject;
        Text2 = Text.transform.Find("Text2").gameObject;

        Text1.SetActive(false);
        Text2.SetActive(false);
    }

    void TextContent(){

        Text Text1t = Text1.GetComponent<Text>();
        Text Text2t = Text2.GetComponent<Text>();

        Text1t.text = "計"+((int)ScoreManager.instance.score).ToString() + "枚";
        Text2t.text = ((int)ScoreManager.instance.score-GameInfo.COOKIE_NUM).ToString() + "まいふえた！";
    }
    
    void titleClick(){
        AudioManager.Instance.StopBGM();
        AudioManager.Instance.PlaySE("button70");
        SceneManager.LoadScene("title");
    }
    void rankingClick(){
        AudioManager.Instance.PlaySE("button70");
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking (((int)ScoreManager.instance.score));
    }
    private IEnumerator AnimationResult(){

        yield return new WaitForSeconds(1.0f);
        Text1.SetActive(true);
        yield return new WaitForSeconds(1.0f);

        Text2.SetActive(true);
        yield return new WaitForSeconds(1.0f);

        button_title.SetActive(true);
        button_ranking.SetActive(true);

    }
}
