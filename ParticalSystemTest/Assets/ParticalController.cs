using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticalController : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] ParticleSystems;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            play_button();
        }
    }

    public void play_button()
    {
        foreach(ParticleSystem PS in ParticleSystems)
        {
            PS.Play();
        }
    }
}
