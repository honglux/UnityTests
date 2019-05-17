using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneTest : MonoBehaviour
{
    private float timer;

    public float counter;

    public CloneTest(CloneTest other_CT)
    {
        Debug.Log("constructor called!!!");
        Debug.Log("other_CT.counter "+ other_CT.counter);

        this.timer = other_CT.timer;
        this.counter = other_CT.counter;
    }

    // Start is called before the first frame update
    void Awake()
    {
        timer = 5.0f;
        counter = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("timer " + timer);
        timer -= Time.deltaTime;
        counter += Time.deltaTime;
        move();
        //spawn();
        deactivate();
    }

    private void move()
    {
        Vector3 pos = new Vector3(counter * 1.0f, counter * 1.0f, 20.0f);
        transform.Translate((pos - transform.position).normalized * Time.deltaTime * 1.0f, 
                                                                        Space.World);
    }

    private void spawn()
    {
        if(timer < 0.0f)
        {
            GameObject obj = Instantiate(gameObject);
            CloneTest CT = obj.GetComponent<CloneTest>();
            timer = 5.0f;
            CT.set_para(this);
            //CT = new CloneTest(this);
        }
    }

    private void deactivate()
    {
        if (timer < 0.0f)
        {
            timer = 5.0f;
            gameObject.SetActive(false);
        }
    }

    private CloneTest get_self()
    {
        return this;
    }

    public void set_para(CloneTest other_CT)
    {
        this.timer = other_CT.timer;
        this.counter = other_CT.counter;
    }
}
