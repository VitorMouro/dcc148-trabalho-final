using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Instrucoes");
    }

    public void Creditos()
    {
        SceneManager.LoadScene("Creditos");
    }
}
