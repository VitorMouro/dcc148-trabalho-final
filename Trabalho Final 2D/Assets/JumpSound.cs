using UnityEngine;

public class JumpSound : MonoBehaviour
{
    public static JumpSound instance;
    
    void Awake()
    {
        if(instance != null) {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
}
