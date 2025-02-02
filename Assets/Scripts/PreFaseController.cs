using UnityEngine;
using UnityEngine.SceneManagement;

public class PreFaseController : MonoBehaviour
{
    public float timeout = 2;
    public string nextScene;

    private float currentTime;

    void Start()
    {
        currentTime = 0;
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime > timeout)
            SceneManager.LoadScene(nextScene);
    }
}
