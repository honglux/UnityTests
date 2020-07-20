
public class RefClass1
{
    public int a;
    public string b;

    public float ref_test2;

    public static RefClass1 IS;

    public RefClass1()
    {
        IS = this;

        this.a = 10;
        this.b = "abc";
        this.ref_test2 = 0.0f;
    }

    //public RefClass1(RefClass1 _RC1)
    //{
    //    this.a = _RC1.a;
    //    this.b = _RC1.b;
    //}

    public void C_RC2()
    {
        RefClass2 RC2 = new RefClass2(this);
        upa();
        RC2.pri_a();
    }

    public void upa()
    {
        a++;
    }

    public void up_RF2()
    {
        ref_test2++;
    }
}
