using System;
using System.Linq;
using TMPro;
using UnityEngine;
public class TextBoxSystem : MonoBehaviour
{
    public static string[] _textToDisplay = {};
    private bool _waitingForEnter = false;
    public GameObject enterButton;
    public GameObject textBox;
    public TMP_Text textLabel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_textToDisplay.Length != 0)
        {
            textBox.SetActive(true);
        }
        else
        {
            textBox.SetActive(false);
        }
        if (_textToDisplay.Length != 0 && !_waitingForEnter)
        {
            GetComponent<TypeWriterEffect>().Run(_textToDisplay[0], textLabel);
            _waitingForEnter = true;
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (TypeWriterEffect.stopped == false)
            {
                TypeWriterEffect.stopped = true;
                textLabel.text = _textToDisplay[0];
            }
            else
            {
                _waitingForEnter = false;
                RemoveAt(ref _textToDisplay, 0);
            }
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
    
    public static void RemoveAt<T>(ref T[] arr, int index)
    {
        for (int a = index; a < arr.Length - 1; a++)
        {
            // moving elements downwards, to fill the gap at [index]
            arr[a] = arr[a + 1];
        }
        // finally, let's decrement Array's size by one
        Array.Resize(ref arr, arr.Length - 1);
    }

    public void DesktopPlant()
    {
        _textToDisplay = _textToDisplay.Append("Well that's not how physics is supposed to work").ToArray();
    }
}
