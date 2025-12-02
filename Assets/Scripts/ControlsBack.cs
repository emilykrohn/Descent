using UnityEngine;
using UnityEngine.SceneManagement;

// Requirement 1
public class ControlsBack : MonoBehaviour
{
    public void OnControlsBack()
    {
        SceneManager.LoadScene(0);
    }
}
