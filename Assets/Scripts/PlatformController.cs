using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public GameObject platformPrefab;
    public int numPlatforms;
    public float verticalDistance;
    public float maxHorizontalDistance;
    private Queue<GameObject> _platformQueue;

    private void Start()
    {
        _platformQueue = new Queue<GameObject>();
        float lastPositionX = 0;
        for (int i = 0; i < numPlatforms; i++)
        {
            GameObject platform = Instantiate(platformPrefab);
            float platformX = i == 0 ? 0 : Random.Range(lastPositionX-maxHorizontalDistance, lastPositionX+maxHorizontalDistance);
            platform.transform.position = new Vector3(platformX, i * verticalDistance, transform.position.z);
            _platformQueue.Enqueue(platform);
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
