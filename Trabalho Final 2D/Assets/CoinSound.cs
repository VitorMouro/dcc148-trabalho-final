using UnityEngine;

public class CoinSound : MonoBehaviour
{
    public static CoinSound instance;
    
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
