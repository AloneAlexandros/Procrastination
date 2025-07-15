using Cinemachine;
using StarterAssets;
using UnityEngine;

public class EnterDesk : MonoBehaviour
{
    public FirstPersonController playerController;
    public Transform chair;
    private Vector3 _previousPlayer;
    private Quaternion _previousPlayerRotation;
    public Transform player;
    public Transform cameraTransform;

    public void OnEnterDesk()
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        playerController.enabled = false;
        _previousPlayer = player.position;
        _previousPlayerRotation = player.rotation;
        player.position = chair.position;
        player.rotation = chair.rotation;
        cameraTransform.gameObject.GetComponent<CinemachineBrain>().enabled = false;
        cameraTransform.position = chair.position;
        cameraTransform.rotation = chair.rotation;
        Variables.ComputerBooted = true;
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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnExitDesk();
        }
    }
}
