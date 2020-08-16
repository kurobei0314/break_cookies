using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorial : MonoBehaviour
{

    GameObject tutorial1,tutorial2,left_arrow,right_arrow,back;

    // Start is called before the first frame update
    void Start()
    {
        tutorial1 = transform.Find("turorial1").gameObject;
        tutorial2 = transform.Find("tutorial2").gameObject;
        left_arrow = transform.Find("left_arrow").gameObject;
        right_arrow = transform.Find("right_arrow").gameObject;
        back = transform.Find("DeleteIcon").gameObject;

        left_arrow.GetComponent<Button>().onClick.AddListener (AllowClick);
        right_arrow.GetComponent<Button>().onClick.AddListener (AllowClick);
        back.GetComponent<Button>().onClick.AddListener (BackClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AllowClick(){

        tutorial1.SetActive(!(tutorial1.activeSelf));
        tutorial2.SetActive(!(tutorial2.activeSelf));
        AudioManager.Instance.PlaySE("button70");
    }

    public void BackClick(){

        this.gameObject.SetActive(false); 
        AudioManager.Instance.PlaySE("button70");       
    }

    public void TutorialInitialize(){
        tutorial1.SetActive(true);
        tutorial2.SetActive(false);
    }
}
