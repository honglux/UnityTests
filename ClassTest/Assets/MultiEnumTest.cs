using UnityEngine;
using UnityEditor;

public class MultiEnumTest : EditorWindow
{
    static int flags = 0;
    static string[] options = new string[] { "CanJump", "CanShoot", "CanSwim" };

    //[MenuItem("Examples/Mask Field usage")]
    //static void Init()
    //{
    //    MultiEnumTest window = (MultiEnumTest)GetWindow(typeof(MultiEnumTest));
    //    window.Show();
    //}

    void OnGUI()
    {
        flags = EditorGUILayout.MaskField("Player Flags", flags, options);
    }
}