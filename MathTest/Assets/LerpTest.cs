using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpTest : MonoBehaviour
{
    [SerializeField] private Vector3 NewPos;
    [SerializeField] private float time;

    private float s_time;
    private Vector3 speed;
    private float journeyLength;
    private float mag_speed;

    private void Awake()
    {
        this.s_time = 0.0f;
        this.speed = new Vector3();
        this.journeyLength = 0.0f;
        this.mag_speed = 0.0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        s_time = Time.time;
        journeyLength = Vector3.Distance(NewPos, transform.position);
        speed = (NewPos - transform.position) / time;
        mag_speed = 10;
    }

    // Update is called once per frame
    void Update()
    {
        // Distance moved equals elapsed time times speed..
        //float distCovered = (Time.time - s_time) * speed;

        // Fraction of journey completed equals current distance divided by total distance.
        //float fractionOfJourney = distCovered / journeyLength;

        // Set our position as a fraction of the distance between the markers.
        transform.position = 
            Vector3.Lerp(transform.position, NewPos, mag_speed * Time.deltaTime);

        //transform.position = Vector3.SmoothDamp()
    }
}
