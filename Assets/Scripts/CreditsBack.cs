using UnityEngine;
using UnityEngine.SceneManagement;

// Requirement 1 
public class CreditsBack : MonoBehaviour
{
  public void OnCreditsBack()
    {
        SceneManager.LoadScene(0);
    }
}
