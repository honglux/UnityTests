using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Controller1 : MonoBehaviour
{
    public Transform O1;
    public Transform O2;
    public Transform A1;
    public Transform A2;
    public Transform H;
    public Transform D1;
    public Transform D2;
    public Transform GA;
    public float time;
    public TextMesh TM;

    public Animator ani;

    public static Controller1 IS;

    private void Awake()
    {
        IS = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) { ani.SetInteger("state", 1); }
        if (Input.GetKeyDown(KeyCode.Alpha2)) { ani.SetInteger("state", 2); }
        if (Input.GetKeyDown(KeyCode.Alpha3)) { ani.SetInteger("state", 3); }
        if (Input.GetKeyDown(KeyCode.Alpha4)) { ani.SetInteger("state", 4); }
        if (Input.GetKeyDown(KeyCode.Alpha5)) { ani.SetInteger("state", 5); }
        if (Input.GetKeyDown(KeyCode.Alpha6)) { ani.SetInteger("state", 6); }
        if (Input.GetKeyDown(KeyCode.D)) { ani.SetTrigger("Next"); }
    }

    public void SDOC()
    {
        StartCoroutine(DO());
    }

    private IEnumerator DO()
    {
        float timer = 0.0f;
        Controller1.IS.O1.gameObject.SetActive(true);
        while (timer < 1.0f)
        {
            timer += Time.deltaTime;
            yield return null;
        }
        Controller1.IS.O1.gameObject.SetActive(false);
    }

    public void SHL(float degree)
    {
        StartCoroutine(HR(degree));
    }

    private IEnumerator HR(float degree)
    {
        float speed = degree / time;
        float timer = time;
        while (timer >= 0)
        {
            H.eulerAngles += new Vector3(0.0f, speed * Time.deltaTime, 0.0f);
            timer -= Time.deltaTime;
            yield return null;
        }
    }

    public void an_next()
    {
        ani.SetTrigger("Next");
    }

}
