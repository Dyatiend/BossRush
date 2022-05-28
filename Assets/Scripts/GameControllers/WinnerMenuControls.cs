using System.Collections;
using System.Collections.Generic;
using GameControllers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinnerMenuControls : MonoBehaviour
{
    public void BackMenuPressed()
    {
        RoomQueue.reset();
        SceneManager.LoadScene(0);
    }
}
