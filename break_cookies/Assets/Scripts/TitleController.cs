using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{

    [SerializeField]
    GameObject title;

    [SerializeField]
    GameObject notitle;

    [SerializeField]
    GameObject Button;

    [SerializeField]
    GameObject Tutorial;


    [SerializeField]
    GameObject TitleButtonPos;

    [SerializeField]
    GameObject TitleButtonDropPos;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.PlayBGM("story");
        notitle.SetActive(false);
        Tutorial.SetActive(false);
        StartCoroutine("AnimationTitle"); 

        GameObject ButtonStart = Button.transform.Find("button_start").gameObject;
        GameObject ButtonTutorial = Button.transform.Find("button_tutorial").gameObject;

        ButtonStart.GetComponent<Button>().onClick.AddListener (StartClick);
        ButtonTutorial.GetComponent<Button>().onClick.AddListener (TutorialClick);    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator AnimationTitle(){

        RectTransform TextRectTran = title.transform.Find("TitleText").gameObject.GetComponent<RectTransform>();
        RectTransform ButtonRectTran = title.transform.Find("ButtonTitle").gameObject.GetComponent<RectTransform>();

        //タイトルのテキストのアニメーション
        TextRectTran.DOScale (
            new Vector3(3.0f,3.0f,1.0f),　　//終了時点のScale
            0.5f 　　　　　　//時間
        );

        yield return new WaitForSeconds(0.5f);

        TextRectTran.DOScale (
            new Vector3(1.0f,1.0f,1.0f),　　//終了時点のScale
            0.2f 　　　　　　//時間
        );

        yield return new WaitForSeconds(0.2f);

        TextRectTran.DOScale (
            new Vector3(2.0f,2.0f,1.0f),　　//終了時点のScale
            0.2f 　　　　　　//時間
        );

        yield return new WaitForSeconds(0.2f);

        TextRectTran.DOScale (
            new Vector3(1.0f,1.0f,1.0f),　　//終了時点のScale
            1.0f 　　　　　　//時間
        );

        yield return new WaitForSeconds(1.0f);


        //タイトルのボタンのアニメーション
        ButtonRectTran.DOMove (
            TitleButtonDropPos.transform.position,　　//移動後の座標
            1.0f 　　　　　　//時間
        );

        yield return new WaitForSeconds(1.0f);

        ButtonRectTran.DOLocalJump(
            TitleButtonPos.transform.localPosition,      // 移動終了地点
            30,               // ジャンプする力
            2,               // ジャンプする回数
            1.0f              // アニメーション時間
        );

        yield return new WaitForSeconds(1.0f);

        notitle.SetActive(true);

    }
    public void StartClick(){
        //Debug.Log("wa-iwa-i");
        AudioManager.Instance.StopBGM();
        AudioManager.Instance.PlaySE("button70");
        SceneManager.LoadScene("Main");
    }

    public void TutorialClick(){
        AudioManager.Instance.PlaySE("button70");
        Tutorial.GetComponent<tutorial>().TutorialInitialize();
        Tutorial.SetActive(true);
        
    }

}
