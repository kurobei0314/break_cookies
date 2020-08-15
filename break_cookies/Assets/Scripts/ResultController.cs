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

    // Start is called before the first frame update
    void Start()
    {
        TextContent();
    }

    // Update is called once per frame
    void Update()
    {
        button.GetComponent<Button>().onClick.AddListener (titleClick);
    }

    void TextContent(){

        Text Text1 = Text.transform.Find("Text1").gameObject.GetComponent<Text>();
        Text Text2 = Text.transform.Find("Text2").gameObject.GetComponent<Text>();

        Text1.text = "計"+((int)ScoreManager.instance.score).ToString() + "枚";
        Text2.text = ((int)ScoreManager.instance.score-GameInfo.COOKIE_NUM).ToString() + "まいふえた！";

    }
    
    void titleClick(){
        SceneManager.LoadScene("title");
    }
}
