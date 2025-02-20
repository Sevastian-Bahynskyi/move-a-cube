using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    [SerializeField] private Material hitObjectMaterial;

    private void OnCollisionEnter(Collision other)
    {
        HandleHit(other.gameObject);
    }

    private void HandleHit(GameObject player)
    {
        if (!player.CompareTag("Player") || gameObject.CompareTag("Hit"))
            return;

        GetComponent<MeshRenderer>().material = hitObjectMaterial;
        gameObject.tag = "Hit";
        gameObject.GetComponentsInChildren<MeshRenderer>().ToList()
            .ForEach(meshRenderer => meshRenderer.material = hitObjectMaterial);
        Console.WriteLine(gameObject.name);

        Scorer scorer = player.GetComponent<Scorer>();
        if (scorer != null)
        {
            scorer.IncrementScore();
        }
    }
}