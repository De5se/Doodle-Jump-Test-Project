using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    private float _rightBoundX;
    private float _leftBoundX;
    [SerializeField] private Transform bottomPosition;
    [SerializeField] private Transform topPosition;
    
    [Header("")]
    [SerializeField] private Vector2 deltaY;
    [Header("")]
    [SerializeField] private Transform platformsParent;
    [SerializeField] private Transform usualPlatform;
    [SerializeField] private List<Platform> platforms = new List<Platform>();
    
    
    private void Start()
    {
        _rightBoundX = Camera.main.ScreenToWorldPoint(new Vector2( Screen.width, 0)).x - usualPlatform.lossyScale.x / 2;
        _leftBoundX = -_rightBoundX;

        GenerateLevel();
    }
    private void GenerateLevel()
    {
        var platformPosition = new Vector2(Random.Range(_leftBoundX, _rightBoundX), bottomPosition.position.y);
        
        while (platformPosition.y < topPosition.position.y)
        {
            var currentPlatform = ChoosePlatform();
            Instantiate(currentPlatform, platformPosition, Quaternion.identity, platformsParent);
            platformPosition = new Vector2(Random.Range(_leftBoundX, _rightBoundX), platformPosition.y + Random.Range(deltaY.x, deltaY.y));
        }
    }

    private Transform ChoosePlatform()
    {
        var currentPlatform = usualPlatform;

        for (var i = 0; i < platforms.Count; i++)
        {
            if (Random.Range(0f, 1f) < platforms[i].chance)
            {
                currentPlatform = platforms[i].platform;
            }
        }
        return currentPlatform;
    }
}

[System.Serializable]
public struct Platform
{
    public Transform platform;
    [Range(0f,1f)] public float chance;
};

