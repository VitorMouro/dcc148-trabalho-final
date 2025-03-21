using UnityEngine;
using UnityEngine.SceneManagement;

public class TrailColliderController : MonoBehaviour
{
    public float timeout = 7.0f;

    private float time = 0;

    void Start()
    {
    }

    void Update()
    {
        time += Time.deltaTime;

        if (time > timeout) {
            Destroy(gameObject);
        }
    }
    
}
