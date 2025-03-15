using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public void StartGameAgain()
    {
        SceneManager.LoadScene("Fase 1");
    }

    public void CreditosAgain()
    {
        SceneManager.LoadScene("Creditos");
    }
}
