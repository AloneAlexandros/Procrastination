using System.Linq;
using Cinemachine;
using StarterAssets;
using UnityEngine;
using UnityEngine.UI;

public class EnterDesk : MonoBehaviour
{
    public FirstPersonController playerController;
    public Transform chair;
    private Vector3 _previousPlayer;
    private Quaternion _previousPlayerRotation;
    public Transform player;
    public Transform cameraTransform;
    public Image image;
    public Sprite image2;

    public void OnEnterDesk()
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        Destroy(playerController);
        _previousPlayer = player.position;
        _previousPlayerRotation = player.rotation;
        player.position = chair.position;
        player.rotation = chair.rotation;
        cameraTransform.gameObject.GetComponent<CinemachineBrain>().enabled = false;
        cameraTransform.position = chair.position;
        cameraTransform.rotation = chair.rotation;
        Variables.ComputerBooted = true;
        image.sprite = image2;
        TextBoxSystem.TextToDisplay = TextBoxSystem.TextToDisplay.Append("Uh oh").ToArray();
        TextBoxSystem.TextToDisplay = TextBoxSystem.TextToDisplay.Append("Guess I shouldn't have procrastinated after all").ToArray();
        TextBoxSystem.TextToDisplay = TextBoxSystem.TextToDisplay.Append("In fact even the developer of this game procrastinated. There was supposed to be a 2d game on the computer screen rn!").ToArray();
        TextBoxSystem.TextToDisplay = TextBoxSystem.TextToDisplay.Append("Instead they just put this dialogue and called it a day").ToArray();
        TextBoxSystem.TextToDisplay = TextBoxSystem.TextToDisplay.Append("Didn't even submit it to the jam, they procrastinated and missed the deadline").ToArray();
        TextBoxSystem.TextToDisplay = TextBoxSystem.TextToDisplay.Append("The irony, amirite?").ToArray();
        TextBoxSystem.TextToDisplay = TextBoxSystem.TextToDisplay.Append("Real stupid, that Alex guy.").ToArray();
    }

    // ReSharper disable Unity.PerformanceAnalysis
    public void OnExitDesk()
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = true;
        playerController.enabled = true;
        player.position = _previousPlayer;
        player.rotation = _previousPlayerRotation;
        cameraTransform.gameObject.GetComponent<CinemachineBrain>().enabled = true;
    }

    void Update()
    {
        //debug code to make sure exitdesk works
        // if (Input.GetKeyDown(KeyCode.Escape))
        // {
        //     OnExitDesk();
        // }
    }
}
