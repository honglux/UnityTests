using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GC : MonoBehaviour
{
    [SerializeField] private Renderer rednerer;
    [SerializeField] private Transform controlP_TRANS;

    [SerializeField] private float INWS1;
    [SerializeField] private float INWS2;
    [SerializeField] private float INWSp;
    [SerializeField] private float ISM;
    [SerializeField] private float ILWS;
    [SerializeField] private float ILWSp;

    [SerializeField] private Slider NWS1S;
    [SerializeField] private Slider NWS2S;
    [SerializeField] private Slider NWSpS;
    [SerializeField] private Slider SMS;
    [SerializeField] private Slider LWSS;
    [SerializeField] private Slider LWSpS;

    [SerializeField] private Vector2 NWS1R;
    [SerializeField] private Vector2 NWS2R;
    [SerializeField] private Vector2 NWSpR;
    [SerializeField] private Vector2 SMR;
    [SerializeField] private Vector2 LWSR;
    [SerializeField] private Vector2 LWSpR;

    private Material material;

    // Start is called before the first frame update
    void Start()
    {
        material = rednerer.sharedMaterial;

        InitSlider();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MenuButton()
    {
        controlP_TRANS.gameObject.SetActive(!controlP_TRANS.gameObject.activeSelf);
    }

    private void InitSlider()
    {
        NWS1S.value = INWS1;
        NWS2S.value = INWS2;
        NWSpS.value = INWSp;
        SMS.value = ISM;
        LWSS.value = ILWS;
        LWSpS.value = ILWSp;
    }

    private float GetValue(float perc, Vector2 range)
    {
        return (range.y - range.x) * perc + range.x;
    }

    public void NWS1SC(float value)
    {
        float tval = GetValue(value, NWS1R);
        material.SetFloat("_Wave1Strength", tval);
    }

    public void NWS2SC(float value)
    {
        float tval = GetValue(value, NWS2R);
        material.SetFloat("_WaveStrength", tval);
    }

    public void NWSpC(float value)
    {
        float tval = GetValue(value, NWSpR);
        material.SetFloat("_Wave1SpeedInv", tval);
        material.SetFloat("_Wave2SpeedInv", tval*2);
    }

    public void SMC(float value)
    {
        float tval = GetValue(value, SMR);
        material.SetFloat("_Smoothness", tval);
    }

    public void LWSC(float value)
    {
        float tval = GetValue(value, LWSR);
        material.SetFloat("_LargeWaveVertexScale", tval);
    }

    public void LWSpC(float value)
    {
        float tval = GetValue(value, LWSpR);
        material.SetFloat("_LargeWaveSpeed", tval);
    }
}
