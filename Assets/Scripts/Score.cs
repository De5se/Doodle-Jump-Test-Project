using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Scrollbar progressBar;
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private Transform player;
    [SerializeField] private Transform finish;
    private float _startDistance;
    private Vector2 _startPosition;

    private void Start()
    {
        _startPosition = player.position;
        _startDistance = Vector2.Distance(_startPosition, finish.position);
    }

    private void Update()
    {
        UpdateScore();
    }

    private void UpdateScore(){
        progressBar.size = Vector2.Distance(player.position, _startPosition) / _startDistance;
        if (progressBar.size >= 1)
        {
            FinishGAme();
        }
    }

    private void FinishGAme()
    {
        this.enabled = false;
        levelManager.WinGAme();
    }
}
