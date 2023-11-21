using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera playerCamera, bossCamera;

    private bool isBossZone = false;

    void changeToBossView()
    {
        bossCamera.Priority = playerCamera.Priority + 1;
    }

    void changeToPlayerView()
    {
        bossCamera.Priority = playerCamera.Priority - 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if (!isBossZone)
            {
                changeToBossView();
            }
            else
            {
                changeToPlayerView();
            }

            isBossZone = !isBossZone;
        }
    }
}
