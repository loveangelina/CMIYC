using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class TextBlink : MonoBehaviour
{
    TextMeshProUGUI flashingText;

    private void Start()
    {
        flashingText = GetComponent<TextMeshProUGUI>();
        StartCoroutine(BlinkText());
    }

    public IEnumerator BlinkText()
    {
        while(true)
        {
            flashingText.text = "";
            yield return new WaitForSeconds(0.5f);
            flashingText.text = "press space to start";
            yield return new WaitForSeconds(0.5f);
        }
    }
}
