using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShootSystem : MonoBehaviour
{
    public string str;

    [SerializeField] private Transform Bullet_Prefab;
    [SerializeField] private Transform Start_TRANS;
    [SerializeField] private GeneralRayCast GRC_script;
    [SerializeField] private Controller_Input CI_script;

    // Start is called before the first frame update
    void Start()
    {
        //str = "0";
        CI_script.ShootDown += instantiate_bullet;
        CI_script.ShootUp += shoot_up;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void shoot()
    {

    }

    private void shoot_up()
    {

    }

    private void instantiate_bullet()
    {
        Transform bullet_OBJ = 
                Instantiate(Bullet_Prefab, Start_TRANS.position, Start_TRANS.rotation);
        bullet_OBJ.GetComponent<TextMeshPro>().text = str;
        bullet_OBJ.GetComponent<NumberProject>().
                            start_move(GRC_script.RayHit.point - Start_TRANS.position);
    }
}
