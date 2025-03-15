using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public GameObject[] platformsPrefab;
    public float[] probabilities;
    public GameObject coinPrefab;
    public int numPlatforms;
    public float verticalDistance;
    public float maxHorizontalDistance;
    public float maxX;
    public float coinHeight;
    private List<GameObject> _platformQueue;

    private void Start()
    {
        _platformQueue = new List<GameObject>();
        float lastPositionX = 0;
        for (int i = 0; i < numPlatforms; i++)
        {
            float rand = Random.Range(0f, 1f);
            int randIndex = 0;
            float sum = 0;
            for (int j = 0; j < probabilities.Length; j++)
            {
                sum =+ probabilities[j];
                if(rand <= sum)
                    randIndex = j;
            }
            if(i == 0 || i == numPlatforms-1)
                randIndex = 0; // Primeira e última plataformas são estáticas
            GameObject platform = Instantiate(platformsPrefab[randIndex]);
            float platformX = i == 0 ? 0 : Random.Range(lastPositionX-maxHorizontalDistance, lastPositionX+maxHorizontalDistance);
            platformX = Mathf.Clamp(platformX, -maxX, maxX);
            platform.transform.position = new Vector3(platformX, i * verticalDistance, transform.position.z);
            _platformQueue.Add(platform);
            lastPositionX = platform.transform.position.x;

            if(i == numPlatforms-1)
            {
                GameObject coin = Instantiate(coinPrefab);
                coin.transform.position = new Vector3(lastPositionX, (numPlatforms-1) * verticalDistance + coinHeight, transform.position.z);
                coin.transform.parent = platform.transform;
            }
        }
    }

    public void Offset(Vector3 offset)
    {
        foreach (GameObject platform in _platformQueue)
        {
            platform.transform.position += offset;
        }
    }

    public void DestroyPlatform(GameObject platform) {
        Destroy(platform);
        _platformQueue.Remove(platform);
    }

    private void Update()
    {
        List<GameObject> shouldDestroy = new List<GameObject>();
        foreach (GameObject platform in _platformQueue)
        {
            bool isOutOfScreen = platform.transform.position.y < Camera.main.transform.position.y - Camera.main.orthographicSize;
            if(platform.transform.position.y < -1 && isOutOfScreen)
                shouldDestroy.Add(platform);
        }

        foreach (GameObject platform in shouldDestroy)
        {
            DestroyPlatform(platform);
        }
    }
}
