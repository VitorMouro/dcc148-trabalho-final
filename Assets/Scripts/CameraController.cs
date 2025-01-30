using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform targetX;
    public float targetY;
    public float t;
    public Vector2 limitX;
    
    void Start()
    {
    }

    void Update()
    {
        float targetX = Math.Clamp(this.targetX.position.x, limitX.x, limitX.y);
        Vector3 target = new Vector3(targetX, targetY, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, target, t);
    }
}
