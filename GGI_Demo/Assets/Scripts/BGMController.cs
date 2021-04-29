using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Control the BGM;
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class BGMController : MonoBehaviour
{
    public static BGMController IS;

    [SerializeField] private AudioSource BGM_AS;

    private void Awake()
    {
        IS = this;
    }

    public void Play_BGM()
    {
        BGM_AS.Play();
    }

    public void Stop_BGM()
    {
        BGM_AS.Stop();
    }
}
