using UnityEngine;

public class UpDownMotionPlatform : MonoBehaviour
{
    [SerializeField] private float amplitude;
    [SerializeField] private float motionSpeed;
    private Vector2 _startPosition;
    private Vector2 _upPosition;
    private Vector2 _downPosition;

    private bool _movingUp;

    private void Start()
    {
        _startPosition = transform.position;
        
        _downPosition = _startPosition;
        _downPosition.y -= amplitude;
        _upPosition = _startPosition;
        _upPosition.y += amplitude;


        if (Random.Range(0, 2) < 1f)
        {
            _movingUp = false;
        }
    }

    private void Update()
    {
        if (_movingUp)
        {
            MoveUp();
        }
        else
        {
            MoveDown();   
        }
    }

    private void MoveUp()
    {
        transform.position = Vector2.MoveTowards(transform.position, _upPosition, motionSpeed * Time.deltaTime);

        if (transform.position.y >= _upPosition.y)
        {
            _movingUp = false;
        }
    }
    
    private void MoveDown()
    {
        transform.position = Vector2.MoveTowards(transform.position, _downPosition, motionSpeed * Time.deltaTime);

        if (transform.position.y <= _downPosition.y)
        {
            _movingUp = true;
        }
    }
}
