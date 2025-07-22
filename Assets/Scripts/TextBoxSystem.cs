using System;
using System.Linq;
using TMPro;
using UnityEngine;
public class TextBoxSystem : MonoBehaviour
{
    public static string[] TextToDisplay = {};
    private bool _waitingForEnter = false;
    public GameObject enterButton;
    public GameObject textBox;
    public TMP_Text textLabel;

    private int currentText = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TextToDisplay = TextToDisplay.Append("Nice! I'm finally back home!").ToArray();
        TextToDisplay = TextToDisplay.Append("Can't wait to dive into that GameJam I joined! I think it started a few hours ago?").ToArray();
        TextToDisplay = TextToDisplay.Append("The theme is quite hard to wrap my head around... what the heck could I do with 'Just get started'").ToArray();
        TextToDisplay = TextToDisplay.Append("...maybe I should get started with cleaning this mess though.").ToArray();
    }

    // Update is called once per frame
    void Update()
    {
        if (TextToDisplay.Length > currentText)
        {
            textBox.SetActive(true);
        }
        else
        {
            textBox.SetActive(false);
        }
        if (TextToDisplay.Length > currentText && !_waitingForEnter)
        {
            GetComponent<TypeWriterEffect>().Run(TextToDisplay[currentText], textLabel);
            _waitingForEnter = true;
        }
        if (Input.GetKeyDown(KeyCode.Return) && TypeWriterEffect.stopped == true)
        {
            currentText++;
            textLabel.text = "";
            _waitingForEnter = false;
        }
        if (TypeWriterEffect.stopped == true)
        {
            enterButton.SetActive(true);
        }
        else
        { 
            enterButton.SetActive(false);
        }
    }

    public void DesktopPlant()
    {
        TextToDisplay = TextToDisplay.Append("Well that's not how physics is supposed to work").ToArray();
    }
}
