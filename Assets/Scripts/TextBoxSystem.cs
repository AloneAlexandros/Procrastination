using System;
using System.Linq;
using Cinemachine;
using StarterAssets;
using TMPro;
using UnityEngine;
public class TextBoxSystem : MonoBehaviour
{
    public static string[] TextToDisplay = {};
    private bool _waitingForEnter = false;
    public GameObject enterButton;
    public GameObject textBox;
    public TMP_Text textLabel;
    public FirstPersonController playerController;
    public CinemachineBrain cameraBrain;
    private bool _waterThePlantsNext = false;
    public Variables variables;
    public Interactions desk;

    private int _currentText = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TextToDisplay = TextToDisplay.Append("Nice! I'm finally back home!").ToArray();
        TextToDisplay = TextToDisplay.Append("Can't wait to dive into that GameJam I joined! I think it started a few hours ago?").ToArray();
        TextToDisplay = TextToDisplay.Append("The theme is quite hard to wrap my head around... what the heck could I do with 'Just get started'").ToArray();
        TextToDisplay = TextToDisplay.Append("...maybe I should get started with cleaning this mess first, though.").ToArray();
    }

    // Update is called once per frame
    void Update()
    {
        if (TextToDisplay.Length > _currentText)
        {
            if (playerController != null)
            {
                playerController.enabled = false;
            }
            cameraBrain.enabled = false;
            textBox.SetActive(true);
        }
        else
        {
            if (_waterThePlantsNext)
            {
                print("water");
                _waterThePlantsNext = false;
                variables.TimeToWaterThePlants();
            }
            
            textBox.SetActive(false);
            if (playerController != null)
            {
                playerController.enabled = true;
            }
            cameraBrain.enabled = true;
        }
        if (TextToDisplay.Length > _currentText && !_waitingForEnter)
        {
            GetComponent<TypeWriterEffect>().Run(TextToDisplay[_currentText], textLabel);
            _waitingForEnter = true;
        }
        if (Input.GetKeyDown(KeyCode.Return) && TypeWriterEffect.stopped == true)
        {
            _currentText++;
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

    public void PlantWork()
    {
        TextToDisplay = TextToDisplay.Append("Alright, now that's done, I should probably get started already...").ToArray();
        TextToDisplay = TextToDisplay.Append("Wait! My plants! When did I last water them?????").ToArray();
        TextToDisplay = TextToDisplay.Append("I gotta do it now!!!!").ToArray();
        _waterThePlantsNext = true;
    }

    public void Gaem()
    {
        TextToDisplay = TextToDisplay.Append("Plants are watered!").ToArray();
        TextToDisplay = TextToDisplay.Append("Guess I have nothing else than to sit on my desk now, huh?").ToArray();
        desk.interactionEnabled = true;
    }
}
