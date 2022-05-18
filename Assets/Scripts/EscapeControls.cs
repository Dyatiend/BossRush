using UnityEngine;

public class EscapeControls : MonoBehaviour
{
    public void ExitPressed()
    {
        Application.Quit();
        Debug.Log("Идешь нахуй");
    }
}
