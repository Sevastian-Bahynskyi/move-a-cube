using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    

    private void OnCollisionEnter(Collision other)
    {
        HandleHit(other.gameObject);
    }

    private void HandleHit(GameObject player)
    {
        if (!player.CompareTag("Player") || gameObject.CompareTag("Hit"))
            return;

        GetComponent<MeshRenderer>().material.color = Color.red;
        gameObject.tag = "Hit";
        gameObject.GetComponentsInChildren<MeshRenderer>().ToList().ForEach(renderer => renderer.material.color = Color.red);
        Console.WriteLine(gameObject.name);

        Scorer scorer = player.GetComponent<Scorer>();
        if (scorer != null)
        {
            scorer.IncrementScore();
        }
    }
}