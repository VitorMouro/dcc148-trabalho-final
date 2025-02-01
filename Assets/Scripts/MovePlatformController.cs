using UnityEngine;

public class MovePlatformController : MonoBehaviour
{
    public float minX, maxX;
    public float minSpeed, maxSpeed;

    private float startX;
    private float speed;

    void Start()
    {
        startX = transform.position.x;
        speed = Random.Range(minSpeed, maxSpeed);
    }

    void Update()
    {
        float moveX = speed * Time.deltaTime;
        float newPosX = transform.position.x + moveX;
        if(newPosX > startX + maxX)
        {
            newPosX = startX + maxX;
            speed *= -1;
        }
        else if(newPosX < startX + minX)
        {
            newPosX = startX + minX;
            speed *= -1;
        }
        transform.position = new Vector3(newPosX, transform.position.y, transform.position.z);
    }
}
