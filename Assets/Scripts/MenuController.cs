using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Fase 1");
    }

    public void Creditos()
    {
        SceneManager.LoadScene("Creditos");
    }
}
