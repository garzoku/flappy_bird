using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public float spawnRate = 1f;
    public float minHeight = -1f;
    public float maxHeight = 1f;

    // Called when script is enabled or disabled
    private void OnEnable()
    {
        // do this is OnEnable and not Start because we want to be able to start and stop
        // this functionality if the player loses and needs to start over, etc...
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }
    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }
    private void Spawn()
    {
        // Here we are cloning our pipes.
        GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity);
        // spawn pipes at random places on Y axis
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }
}


