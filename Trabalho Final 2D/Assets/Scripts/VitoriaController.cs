using UnityEngine;
using UnityEngine.SceneManagement;

public class VitoriaController : MonoBehaviour
{
    public void StartGameInitial()
    {
        SceneManager.LoadScene("Menu");
    }

    public void CreditosInitial()
    {
        SceneManager.LoadScene("Creditos");
    }
}
