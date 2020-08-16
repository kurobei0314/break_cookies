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
    GameObject button;

    GameObject Text1;
    GameObject Text2;


    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.PlayBGM("04_karuiasidoride");
        TextInitiallize();
        TextContent();
        button.SetActive(false);
        button.GetComponent<Button>().onClick.AddListener (titleClick);
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
    private IEnumerator AnimationResult(){

        yield return new WaitForSeconds(1.0f);
        Text1.SetActive(true);
        yield return new WaitForSeconds(1.0f);

        Text2.SetActive(true);
        yield return new WaitForSeconds(1.0f);

        button.SetActive(true);

    }
}
