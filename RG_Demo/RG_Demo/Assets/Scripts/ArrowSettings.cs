using UnityEngine;
using EnumController;

public class ArrowSettings : MonoBehaviour
{
    public Sprite ArrowBodySprite;
    public Sprite ArrowHeadSprite;
    public int ArrowNodeNumber; //Arrow sprite node number;
    public int ArrowSmoothJointNumber;    //Arrow total joints number; Should be larger than ArrowNodeNumber; Should be greater than 2;
    public float ArrowStartScale;
    public float ArrowEndScale;
    public float[] BCurveABCD;  //Coefficient as ABCD for B curve; Kepp the size larger (equal) than 4!!!
    public Vector3[] P12Coeff;  //Coefficient for p1 and p2 for B curve; Keep the size larger (equal) than 2!!!
    public ArrowCurveType CurveType;

}
