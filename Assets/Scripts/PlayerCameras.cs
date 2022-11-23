using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameras : MonoBehaviour
{
    public List<Camera> playerCameras = new();
    private int currentCamera;
    private int currentCameraCount;

    private void Start()
    {
        playerCameras[currentCamera].enabled = true;
        currentCameraCount = 1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            currentCamera++;
            currentCameraCount++;
            if (currentCameraCount > playerCameras.Count)
            {
                currentCamera = 0;
                currentCameraCount = 1;
            }
            for (int i = 0; i < playerCameras.Count; i++)
            {
                if (i == currentCamera)
                {
                    playerCameras[i].enabled = true;
                }
                else
                {
                    playerCameras[i].enabled = false;
                }
            }
        }
    }
}
