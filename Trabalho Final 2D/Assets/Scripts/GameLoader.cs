using UnityEngine;
public class GameLoader : MonoBehaviour
{
    [SerializeField] private GameObject hudPrefab;

    void Start()
    {
        if (!FindAnyObjectByType<HUDController>())
            Instantiate(hudPrefab);
    }
}