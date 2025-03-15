using UnityEngine;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{

    public float lin_speed = 1;
    public float ang_speed = 1;
    public GameObject trailColliderPrefab;
    public float trailColliderInterval = 0.5f;
    public float sensitivity = 1;

    private Rigidbody rb;
    private GameObject cam;
    private GameObject bike;

    private float inclination = 0;
    private float lastTrailColliderTime = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = transform.GetChild(0).gameObject;
        bike = transform.GetChild(1).gameObject;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        Vector3 currentVelocity = rb.linearVelocity;
        Vector3 newVelocity = transform.forward * lin_speed;
        newVelocity.y = currentVelocity.y;
        rb.linearVelocity = newVelocity;
        rb.angularVelocity = Vector3.up * horizontal * ang_speed;

        inclination = Mathf.Lerp(inclination, horizontal, 0.1f);
        bike.transform.localEulerAngles = new Vector3(0, 0, -inclination * 45);

        lastTrailColliderTime += Time.deltaTime;

        if (lastTrailColliderTime > trailColliderInterval) {
            lastTrailColliderTime = 0;
            GameObject trailCollider = Instantiate(trailColliderPrefab, transform.position, transform.rotation);
        }

        UpdateCamera(Input.GetAxis("Mouse X"));
    }

    void UpdateCamera(float mouseX)
    {
        cam.transform.RotateAround(transform.position, Vector3.up, mouseX*sensitivity);
    }
}
