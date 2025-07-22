using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypeWriterEffect : MonoBehaviour
{
    public float TypeWriterSpeed = 50f;
    public static bool stopped= false;
    public void Run(string TextToType, TMP_Text textLabel)
    {
        StartCoroutine(TypeText(TextToType, textLabel));
        stopped = false;
    }

    private IEnumerator TypeText(string TextToType, TMP_Text textLabel)
    {
        float t = 0;
        int charIdex = 0;

        while(charIdex < TextToType.Length && stopped == false) 
        {
            t += Time.deltaTime * TypeWriterSpeed;
            charIdex = Mathf.FloorToInt(t);
            charIdex = Mathf.Clamp(charIdex, 0,TextToType.Length);
            textLabel.text = TextToType.Substring(0, charIdex);
            yield return null;
        }
        textLabel.text = TextToType;
        stopped= true;  
    }
}
