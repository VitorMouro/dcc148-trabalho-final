using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float gravity;
    
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    private PlatformController _platformController;
    private Camera _camera;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _platformController = FindFirstObjectByType<PlatformController>();
        _camera = Camera.main;
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        
        _rigidbody.linearVelocityX = horizontal * speed;
        _rigidbody.linearVelocityY += gravity * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Contains("Platform"))
        {
            if (_rigidbody.linearVelocityY > 0)
                return;
            
            SpriteRenderer platformSr = other.GetComponent<SpriteRenderer>();
            float platformY = platformSr.bounds.max.y;
            // float playerY = _spriteRenderer.bounds.min.y;
            float playerHalfHeight = _spriteRenderer.bounds.size.y / 2;
            
            transform.position = new Vector3(transform.position.x, platformY + playerHalfHeight, transform.position.z);
            _rigidbody.linearVelocityY = jumpForce;

            Vector3 offset = Vector3.up * (-platformY);
            _platformController.Offset(offset); 
            transform.Translate(offset);
            _camera.transform.Translate(offset);
        }
    }
}
