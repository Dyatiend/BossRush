using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControls : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    public void PeepobChosen()
    {
        PlayerManager.Prefab = player1;
        SceneManager.LoadScene(1);
    }
    public void VoidChosen()
    {
        PlayerManager.Prefab = player2;
        SceneManager.LoadScene(2);
    }

    public void ExitPressed()
    {
        Application.Quit();
        Debug.Log("Идешь нахуй");
    }
}
