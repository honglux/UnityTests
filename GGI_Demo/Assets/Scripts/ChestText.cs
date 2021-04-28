using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChestText : MonoBehaviour
{
    [SerializeField] private Transform chest_text_TMP_TRANS;
    [SerializeField] private Transform pooper_SR_TRANS;
    [SerializeField] private string init_text;
    [SerializeField] private string format;

    /// <summary>
    /// Show the text with amount;
    /// </summary>
    /// <param name="amount"></param>
    public void Show_text(float amount)
    {
        chest_text_TMP_TRANS.GetComponent<TextMeshPro>().text = init_text + amount.ToString(format);
        chest_text_TMP_TRANS.GetComponent<MeshRenderer>().enabled = true;
    }

    /// <summary>
    /// Hide the text;
    /// </summary>
    public void Hide_text()
    {
        chest_text_TMP_TRANS.GetComponent<MeshRenderer>().enabled = false;
    }

    /// <summary>
    /// Update the chest text;
    /// </summary>
    /// <param name="amount"></param>
    public void Update_text(float amount)
    {
        chest_text_TMP_TRANS.GetComponent<TextMeshPro>().text = init_text + amount.ToString(format);
    }

    public void Change_color(Color color)
    {
        chest_text_TMP_TRANS.GetComponent<TextMeshPro>().color = color;
    }

    public void Show_pooper()
    {
        pooper_SR_TRANS.GetComponent<SpriteRenderer>().enabled = true;
    }

    public void Hide_pooper()
    {
        pooper_SR_TRANS.GetComponent<SpriteRenderer>().enabled = false;
    }
}
