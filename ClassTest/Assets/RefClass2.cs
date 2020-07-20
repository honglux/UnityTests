using System.Security.Cryptography;
using UnityEngine;

public class RefClass2
{

    public int c;

    private RefClass1 RF1;

    public static RefClass2 IS;

    public RefClass2()
    {
        IS = this;

        this.c = 0;
    }

    //By default, = is getting the reference;
    public RefClass2(RefClass1 _refClass1)
    {
        this.RF1 = _refClass1;
    }
    
    public void pri_a()
    {
        Debug.Log("!!!!! "+RF1.a.ToString());
    }

}
