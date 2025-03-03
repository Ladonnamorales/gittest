using UnityEngine;
using UnityEngine.SceneManagement;
using static allControl;

public class EndMenu : MonoBehaviour
{
    public void ReloadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
        GameManager.Instance.score = 0;
    }
}
