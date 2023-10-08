using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderPosition : MonoBehaviour
{

    private Transform player;

    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        if (player != null)
        {
            transform.position = player.position + new Vector3(0, 1.5f, 0);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
