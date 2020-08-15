using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleButton : MonoBehaviour
{
    [SerializeField]
    GameObject ButtonStart;

    [SerializeField]
    GameObject ButtonTutorial;

    // Start is called before the first frame update
    void Start()
    {
        //GameObject ButtonStart = transform.Find("button_start").gameObject;
        //GameObject ButtonTutorial = transform.Find("button_tutorial").gameObject;

        ButtonStart.GetComponent<Button>().onClick.AddListener (StartClick);
        ButtonTutorial.GetComponent<Button>().onClick.AddListener (TutorialClick);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartClick(){
        Debug.Log("wa-iwa-i");
        //SceneManager.LoadScene("Main");
    }

    public void TutorialClick(){
        Debug.Log("wa-iwa-iwa-iwa-i");
    }
}
