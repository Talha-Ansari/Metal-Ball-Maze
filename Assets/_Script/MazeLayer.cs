using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class MazeLayer : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Transform spawnPoint;
    [SerializeField] CinemachineVirtualCamera cinemachineVirtualCamera;
    [SerializeField] float defaultViewSize = 5, transitionSize = 9;
    private void Start()
    {
        // cinemachineVirtualCamera.m_Lens.OrthographicSize = transitionSize;
        ResetLayer();
    }

    //     IEnumerator ResetCameraSize()
    //     {
    // while(Mathf())
    //         yield return WaitForSeconds()
    //     }
    public void ResetLayer()
    {
        player.localPosition = spawnPoint.localPosition;
    }
}
