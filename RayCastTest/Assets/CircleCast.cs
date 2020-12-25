using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CircleCast : MonoBehaviour
{
    [SerializeField] private Transform indicator;
    [SerializeField] private float max_dist;
    [SerializeField] private float end_width;
    [SerializeField] private float angle_range;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //test1();
        test2();
    }

    private void test1()
    {
        Ray[] rays = Circle_rays(transform.position, 10.0f, 0.5f);
        rays = CR_angle_filter(rays, transform.forward, 180.0f);
        RaycastHit hit_IF;
        foreach(Ray ray in rays)
        {
            if (Physics.Raycast(ray, out hit_IF, 10.0f)) { indicator.position = hit_IF.point; }
        }
    }

    public static Ray[] Circle_rays(Vector3 start_pos, float distance, float end_width)
    {
        float theta = Mathf.Asin((end_width / 2.0f) / distance) * 2;
        int num = (int)Math.Ceiling(360.0f / theta);
        Ray[] rays = new Ray[num];
        float temp_theta = 0.0f;
        Vector3 temp_dir = new Vector3();
        for (int i = 0; i < num; i++)
        {
            temp_dir = new Vector3(Mathf.Cos(temp_theta * Mathf.Deg2Rad), 0.0f, Mathf.Sin(temp_theta * Mathf.Deg2Rad));
            rays[i] = new Ray(start_pos, temp_dir);
            temp_theta += theta;
        }
        //Debug.Log("!!!!! " + Vector3.Angle(ref_dir_xz, ray.direction));
        return rays;
    }

    public static Ray[] CR_angle_filter(Ray[] rays, Vector3 ref_dir, float angle_range)
    {
        Vector3 ref_dir_xz = new Vector3(ref_dir.x, 0.0f, ref_dir.z);
        List<Ray> res = new List<Ray>();
        foreach (Ray ray in rays)
        {
            //Debug.Log("!!!!! " + Vector3.Angle(ref_dir_xz, ray.direction));
            if (Mathf.Abs(Vector3.Angle(ref_dir_xz, ray.direction)) <= angle_range)
            {
                res.Add(ray);
            }
        }
        return res.ToArray();
    }

    private void test2()
    {
        Ray[] rays = Circle_ray_filted(transform.position, max_dist, end_width,
            transform.forward, angle_range);
        foreach(Ray ray in rays)
        {
            Debug.DrawLine(transform.position, ray.GetPoint(max_dist));
        }
        
    }

    public static Ray[] Circle_ray_filted(Vector3 start_pos, float distance, float end_width,
    Vector3 ref_dir, float angle_range)
    {
        float theta = Mathf.Asin((end_width / 2.0f) / distance) *Mathf.Rad2Deg * 2;
        Vector3 ref_dir_xz = new Vector3(ref_dir.x, 0.0f, ref_dir.z);
        float ref_theta = Angle_from_dir_hori(Vector3.right, ref_dir_xz);
        List<Ray> res = new List<Ray>();
        float temp_theta = 0.0f;
        Vector3 temp_dir = new Vector3();
        while (temp_theta < 360.0f)
        {
            if (Angle_in_range(temp_theta, Angle_360round(ref_theta - angle_range / 2.0f), Angle_360round(ref_theta + angle_range / 2.0f)))
            {
                //Debug.Log("!!!!!!" + temp_theta);
                temp_dir = Dir_from_angle_hori(Vector3.right, temp_theta);
                res.Add(new Ray(start_pos, temp_dir));
            }
            temp_theta += theta;
        }
        Circle_ray_add_border(start_pos, ref_dir, angle_range, ref res);
        return res.ToArray();
    }

    public static void Circle_ray_add_border(Vector3 start_pos, Vector3 ref_dir, float angle_range,
        ref List<Ray> rays)
    {
        rays.Add(new Ray(start_pos, ref_dir));
        float ref_theta = Angle_from_dir_hori(Vector3.right, ref_dir);
        Vector3 left_dir = Dir_from_angle_hori(Vector3.right, ref_theta - angle_range / 2.0f);
        rays.Add(new Ray(start_pos, left_dir));
        Vector3 right_dir = Dir_from_angle_hori(Vector3.right, ref_theta + angle_range / 2.0f);
        rays.Add(new Ray(start_pos, right_dir));
    }

    public static Vector3 Dir_from_angle_hori(Vector3 ref_dir, float theta)
    {
        float ref_angle = Mathf.Rad2Deg * Mathf.Atan2(ref_dir.z, ref_dir.x);
        float angle = ref_angle + theta;
        float x = Mathf.Cos(angle * Mathf.Deg2Rad);
        float z = Mathf.Sin(angle * Mathf.Deg2Rad);
        return new Vector3(x, 0.0f, z);
    }

    public static float Angle_from_dir_hori(Vector3 ref_dir, Vector3 dir)
    {
        return Mathf.Rad2Deg * Mathf.Atan2(dir.z, dir.x) -
            Mathf.Rad2Deg * Mathf.Atan2(ref_dir.z, ref_dir.x);
    }

    public static float Angle_360round(float theta)
    {
        if (theta < 0) { return theta + 360; }
        if (theta >= 360) { return theta - 360; }
        return theta;
    }

    public static bool Angle_in_range(float theta, float low_bound, float high_bound)
    {
        //Debug.Log(theta + "|" + low_bound + "|" + high_bound);
        if (low_bound >= high_bound) { return theta <= high_bound || theta >= low_bound; }
        return theta >= low_bound && theta <= high_bound;
    }
}
