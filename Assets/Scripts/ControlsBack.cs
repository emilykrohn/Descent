using UnityEngine;
using UnityEngine.SceneManagement;

// 19. 
public class ControlsBack : MonoBehaviour
{
    public void OnControlsBack()
    {
        SceneManager.LoadScene(0);
    }
}
