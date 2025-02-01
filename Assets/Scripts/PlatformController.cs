using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject coinPrefab;
    public int numPlatforms;
    public float verticalDistance;
    public float maxHorizontalDistance;
    public float maxX;
    public float coinHeight;
    private Queue<GameObject> _platformQueue;

    private void Start()
    {
        _platformQueue = new Queue<GameObject>();
        float lastPositionX = 0;
        for (int i = 0; i < numPlatforms; i++)
        {
            GameObject platform = Instantiate(platformPrefab);
            float platformX = i == 0 ? 0 : Random.Range(lastPositionX-maxHorizontalDistance, lastPositionX+maxHorizontalDistance);
            platformX = Mathf.Clamp(platformX, -maxX, maxX);
            platform.transform.position = new Vector3(platformX, i * verticalDistance, transform.position.z);
            _platformQueue.Enqueue(platform);
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

    private void Update()
    {
    }
}
