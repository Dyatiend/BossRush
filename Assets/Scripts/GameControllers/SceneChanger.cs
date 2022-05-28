using System.Collections;
using System.Collections.Generic;
using GameControllers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.tag == ("Player")) {
            RoomQueue.loadNextRoom();
        }
    }
}
