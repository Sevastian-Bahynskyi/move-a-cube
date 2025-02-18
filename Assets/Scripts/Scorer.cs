using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorer : MonoBehaviour
{
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncrementScore()
    {
        Debug.Log($"You've bumped into a thing {++score} times.");
    }
    
    public int GetFinalScore()
    {
        int obstacleNumber = FindObjectsByType<ObjectHit>(FindObjectsSortMode.InstanceID).Length;
        return 100 - 100 * score / obstacleNumber;
    }
}
