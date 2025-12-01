using UnityEngine;
using UnityEngine.SceneManagement;


public class ControlsBack : MonoBehaviour
{
    public void OnControlsBack()
    {
        SceneManager.LoadScene(0);
    }
}
