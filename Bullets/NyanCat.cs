using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NyanCat : MonoBehaviour
{
    public Transform player;  
    public GameObject CatPrefab;  
    public float yOffsetMin = -5f;  
    public float yOffsetMax = 5f;

    public float delay = 10f;
    private float timer;

    public int repeatCount = 5;
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
        Vector3 spawnPosition = player.position + new Vector3(-10f, Random.Range(yOffsetMin, yOffsetMax), 0f);
        Instantiate(CatPrefab, spawnPosition, Quaternion.identity);
    }

    private void CancelRepeating()
    {
        CancelInvoke("InTheSupernpva");
    }  
}
