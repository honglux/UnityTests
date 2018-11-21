using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.CoreModule;

public class GameController : MonoBehaviour {

    int testv1 = 100;

    public GameObject global;

    private Global glo_script;

    void Awake()
    {
        //DontDestroyOnLoad(this);

        Debug.Log("Awaked");
        //Debug.Log("testv1 "+ testv1);
    }

    void Start()
    {
        Debug.Log("Started");
        //Debug.Log("testv1 " + testv1);

        if (GameObject.Find("Global") == null)
        {
            GameObject glo_instant = Instantiate(global,new Vector3(),new Quaternion())
                                            as GameObject;
            glo_instant.name = "Global";
        }
        glo_script = GameObject.Find("Global").GetComponent<Global>();

        //Debug.Log("global.glotesst1 " + glo_script.glotesst1);

    }

    public void ToScene1()
    {
        testv1++;
        glo_script.glotesst1++;
        SceneManager.LoadScene("TestScene1");
    }

    public void ToScene2()
    {
        testv1++;
        glo_script.glotesst1++;
        SceneManager.LoadScene("TestScene2");
    }
}
