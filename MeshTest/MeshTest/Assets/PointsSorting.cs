﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PointsSorting : MonoBehaviour
{

    [SerializeField] private Vector2[] points;

    private Vector2 center;

    // Start is called before the first frame update
    void Start()
    {
        this.center = new Vector2();

        sort_p();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool less(Vector2 a, Vector2 b)
    {
        if (a.x - center.x >= 0 && b.x - center.x < 0)
            return true;
        if (a.x - center.x < 0 && b.x - center.x >= 0)
            return false;
        if (a.x - center.x == 0 && b.x - center.x == 0)
        {
            if (a.y - center.y >= 0 || b.y - center.y >= 0)
                return a.y > b.y;
            return b.y > a.y;
        }

        // compute the cross product of vectors (center -> a) x (center -> b)
        float det = (a.x - center.x) * (b.y - center.y) - (b.x - center.x) * (a.y - center.y);
        if (det < 0)
            return true;
        if (det > 0)
            return false;

        // points a and b are on the same line from the center
        // check which point is closer to the center
        float d1 = (a.x - center.x) * (a.x - center.x) + (a.y - center.y) * (a.y - center.y);
        float d2 = (b.x - center.x) * (b.x - center.x) + (b.y - center.y) * (b.y - center.y);
        return d1 > d2;
    }

    private void sort_p()
    {
        List<Vector2> list_p = points.ToList();
        list_p.Sort((p1, p2) => (less(p1, p2) ? 1 : 0));
        debug_list(list_p);
    }

    private void debug_list(List<Vector2> list_p)
    {
        foreach(Vector2 poi in list_p)
        {
            Debug.Log("poi " + poi.ToString("F2"));
        }
    }

    private void center_cal()
    {
        float ave_x = 0.0f;
        float ave_y = 0.0f;
        int num = 0;
        foreach(Vector2 poi in points)
        {
            num++;
            ave_x += poi.x;
            ave_y += poi.y;
        }
        center.x = ave_x / (float)num;
        center.y = ave_y / (float)num;
    }
}
