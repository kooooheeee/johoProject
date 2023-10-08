using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    public Transform player;  
    public GameObject DogPrefab;  
    public float yOffsetMin = -5f;  
    public float yOffsetMax = 5f;

    public float delay = 10f;
    public int atk = 15;
    private float timer;

    public int repeatCount = 1;
    public float interval = 0.2f;

    void Update()
    {
        timer += Time.deltaTime;
        if(timer > delay)
        {
            InvokeRepeating("InTheSupernpva", 0f, interval);
            Invoke("CancelRepeating", repeatCount * interval);
            timer = 0.0f;
        }

    }

    private void InTheSupernpva()
    {
        Vector3 spawnPosition = player.position + new Vector3(-18f, Random.Range(yOffsetMin, yOffsetMax), 0f);
        Instantiate(DogPrefab, spawnPosition, Quaternion.identity);
    }

    private void CancelRepeating()
    {
        CancelInvoke("InTheSupernpva");
    }
}
