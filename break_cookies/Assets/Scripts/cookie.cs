using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cookie : MonoBehaviour
{
    //　円が大きくなるスピード
    float speed=1;

    int CookieKind=0;
    string BreakImagePass="";

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
        AudioManager.Instance.PlaySE("cookie_break");
        StartCoroutine("AnimationCookie");
        ScoreManager.instance.score += 1;
    }

    private IEnumerator AnimationCookie(){

        ChangeImage(BreakImagePass);
        yield return new WaitForSeconds(0.5f);
        this.gameObject.SetActive(false);
    }

    public void ChangeCookieImage(int kindnum){

        string ImagePass="";
        CookieKind=kindnum;

        switch (CookieKind)
        {
            case 1:
                ImagePass = "Pictures/cookie1";
                BreakImagePass = "Pictures/cookie1_break";
                break;

            case 2:
                ImagePass = "Pictures/cookie2";
                BreakImagePass = "Pictures/cookie2_break";
                break;
            
            case 3:
                ImagePass = "Pictures/cookie3";
                BreakImagePass = "Pictures/cookie3_break";
                break;

            case 4:
                ImagePass = "Pictures/cookie4";
                BreakImagePass = "Pictures/cookie4_break";
                break;
            
        }
        ChangeImage(ImagePass);
    }

    public float GetSpeed(){
        return speed;
    }

    public void SetSpeed(float num){
        speed = num;
    }

    public void ChangeImage(string pass){

        Sprite sprite = Resources.Load<Sprite>(pass);
        this.GetComponent<Image>().sprite = sprite;
    }

}

