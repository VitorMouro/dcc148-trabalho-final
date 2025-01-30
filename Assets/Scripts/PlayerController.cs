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
    private Material _background;
    private Animator _animator;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _platformController = FindFirstObjectByType<PlatformController>();
        _camera = Camera.main;
        GameObject background = GameObject.Find("Background");
        _background = background.GetComponent<MeshRenderer>().material;
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        if (horizontal > 0)
            _spriteRenderer.flipX = true;
        else if (horizontal < 0)
            _spriteRenderer.flipX = false;
        
        _rigidbody.linearVelocityX = horizontal * speed;
        _rigidbody.linearVelocityY += gravity * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Contains("Platform"))
        {
            if (_rigidbody.linearVelocityY > 0)
                return;
            
            _animator.SetTrigger("Crouch");
            
            SpriteRenderer platformSr = other.GetComponent<SpriteRenderer>();
            float platformY = platformSr.bounds.max.y;
            // float playerY = _spriteRenderer.bounds.min.y;
            float playerHalfHeight = _spriteRenderer.bounds.size.y / 2;
            
            transform.position = new Vector3(transform.position.x, platformY + playerHalfHeight, transform.position.z);
            _rigidbody.linearVelocityY = jumpForce;

            Vector3 offset = Vector3.up * (-platformY);
            _platformController.Offset(offset); 
            transform.Translate(offset);
            Vector2 textureOffset = offset / 0.675f;
            _background.mainTextureOffset += textureOffset;
            _camera.transform.Translate(offset);
        }
    }
}
