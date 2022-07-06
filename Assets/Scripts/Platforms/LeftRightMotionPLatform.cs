using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRightMotionPLatform : MonoBehaviour
{
    [SerializeField] private float motionSpeed;
    private Vector2 _rightPosition;
    private Vector2 _leftPosition;

    private bool _movingRight;

    private void Start()
    {
        DefineBounds();
    }

    private void Update()
    {
        if (_movingRight)
        {
            MoveRight();
        }
        else
        {
            MoveLeft();   
        }
    }

    private void MoveRight()
    {
        transform.position = Vector2.MoveTowards(transform.position, _rightPosition, motionSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, _rightPosition) <= 0.1f)
        {
            _movingRight = false;
        }
    }
    
    private void MoveLeft()
    {
        transform.position = Vector2.MoveTowards(transform.position, _leftPosition, motionSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, _leftPosition) <= 0.1f)
        {
            _movingRight = true;
        }
    }


    private void DefineBounds()
    {
        var maxRight = Camera.main.ScreenToWorldPoint(new Vector2( Screen.width, 0)).x - transform.lossyScale.x / 2;
        var maxLeft = -maxRight;
        var startPosition = new Vector2(Random.Range(maxLeft, maxRight) / 2, transform.position.y);
            
        var amplitude = Mathf.Min(startPosition.x - maxLeft, maxRight - startPosition.x);
        _leftPosition = new Vector2(startPosition.x - amplitude, startPosition.y);
        _rightPosition = new Vector2(startPosition.x + amplitude, startPosition.y);
    }
}
