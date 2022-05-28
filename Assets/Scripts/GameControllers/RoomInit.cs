using System.Collections;
using System.Collections.Generic;
using GameControllers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomInit : MonoBehaviour
{
    public Transform playerPoint;
    public Transform bossPoint;

    public GameObject CameraHUD;
    
    private void Awake() {
        Instantiate(CameraHUD);
        
        Instantiate(CharacterSelectControls.playerCharacter.playerPrefab, playerPoint.position, playerPoint.rotation);
        string currentRoomName = SceneManager.GetActiveScene().name;
        if (currentRoomName != CharacterSelectControls.playerCharacter.roomName)
        {
            Instantiate(CharacterManager.getByRoomName(currentRoomName).bossPrefab, bossPoint.position, bossPoint.rotation);
        }
    }
}
