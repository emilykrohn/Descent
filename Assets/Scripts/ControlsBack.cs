using UnityEngine;
using UnityEngine.SceneManagement;

// Requirement #
public class ControlsBack : MonoBehaviour
{
    
    public void OnControlsBack()
    {
        SceneManager.LoadScene(0);
    }
}
