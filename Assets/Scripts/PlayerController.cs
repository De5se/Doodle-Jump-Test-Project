using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    [SerializeField] private float collisionVelocityY;
    [SerializeField] private float motionSpeed;

    private float _rightBoundX;
    private float _leftBoundX;

    private Animator _animator;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

        _rightBoundX = Camera.main.ScreenToWorldPoint(new Vector2( Screen.width, 0)).x;
        _leftBoundX = -_rightBoundX;
    }
    
    private void Update()
    {
        PlayerMotion();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (_rigidbody.velocity.y > 0) return;
        
        if (other.gameObject.CompareTag("Platform"))
            Jump();
        
        if (other.gameObject.CompareTag("DeadZone"))
        {
            LoseGame();
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (_rigidbody.velocity.y > 0)
        {
            return;
        }

        if (collider.CompareTag("Platform"))
        {
            collider.GetComponent<TrapPlatform>().Break();
        }        
    }


    private void PlayerMotion()
    {
        var horizontal = Application.platform == RuntimePlatform.Android ? Input.acceleration.x : Input.GetAxis("Horizontal");
        
        var targetVelocity = _rigidbody.velocity;
        targetVelocity.x = horizontal * motionSpeed;
        _rigidbody.velocity = targetVelocity;
        CheckBounds();
    }

    /// <summary>
    /// Check if player inside screen, else teleport him
    /// </summary>
    private void CheckBounds()
    {
        if (transform.position.x > _rightBoundX)
        {
            Teleport(_leftBoundX);
        }
        if (transform.position.x < _leftBoundX)
        {
            Teleport(_rightBoundX);
        }
    }
    private void Teleport(float xPosition)
    {
        Vector2 targetPosition = new Vector2(xPosition, transform.position.y);
        transform.position = targetPosition;
    }
    private void Jump()
    {
        var targetVelocity = _rigidbody.velocity;
        targetVelocity.y = collisionVelocityY;
        _rigidbody.velocity = targetVelocity;
        
        _animator.Play("Jump");
    }

    private void LoseGame()
    {
        _rigidbody.bodyType = RigidbodyType2D.Static;
        this.enabled = false;
    }
}
