using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinnerMenuControls : MonoBehaviour
{
    public void BackMenuPressed()
    {
        SceneManager.LoadScene(0);
    }
}
