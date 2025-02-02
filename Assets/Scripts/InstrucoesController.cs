using UnityEngine;
using UnityEngine.SceneManagement;

public class InstrucoesController : MonoBehaviour
{
    public void IntrucoesStartGame()
    {
        SceneManager.LoadScene("PreFase1");
    }
}
