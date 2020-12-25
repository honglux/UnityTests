using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabTest3 : MonoBehaviour
{
    //Need to be GameObject!!!!!;
    [SerializeField] private GameObject IF1;
    [SerializeField] private GameObject IF2;
    [SerializeField] private GameObject IF3;

    // Start is called before the first frame update
    void Start()
    {
        test1();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void test1()
    {


        //IF1.PrintA();
        //IF1.PrintB();
        //IF2.PrintA();
        //IF2.PrintB();
        //IF3.PrintA();
        //IF3.PrintB();

        //Instantiate(IF2.Get_GO());
    }
}
