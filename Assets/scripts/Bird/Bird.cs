using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(birdMover))]
[RequireComponent(typeof(ScoreCounter))]
[RequireComponent(typeof(BirdCollisionHandLer))]
public class Bird : MonoBehaviour
{
    private birdMover _birdMover;
    private ScoreCounter _scoreCounter;
    private BirdCollisionHandLer _handLer;

    public event Action GameOver;

    private void Awake()
    {
        _birdMover = GetComponent<birdMover>();
        _scoreCounter = GetComponent<ScoreCounter>();
        _handLer = GetComponent<BirdCollisionHandLer>();
    }

    private void OnEnable()
    {
        _handLer.CollisionDetected += ProcessCollision;
    }

    private void OnDisable()
    {
        _handLer.CollisionDetected -= ProcessCollision;
    }

    private void ProcessCollision(IInteractable interactable)
    {
        if (interactable.GetComponent<Pipe>())
        {
            GameOver?.Invoke();
        }
        else if (interactable.GetComponent<ScoreCounter>())
        {
            _scoreCounter.Add();
        }
    }

    public void Reset()
    {
        _scoreCounter.Reset();
        _birdMover.Reset();
    }
}