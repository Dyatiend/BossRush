using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControls : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    private void Start() {
        RoomManager.SetupRooms();
    }

    public void PeepobChosen()
    {
        PlayerManager.Prefab = player1;
        RoomManager.DeleteRoom(1);
        SceneManager.LoadScene(1);
    }
    public void VoidChosen()
    {
        PlayerManager.Prefab = player2;
        RoomManager.DeleteRoom(2);
        SceneManager.LoadScene(2);
    }
}
