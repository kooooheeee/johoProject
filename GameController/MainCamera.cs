using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public float speed = 4f;
    PlayerControler player;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerControler>();
    }
    
    void Update()
    {
        if(player != null)
        {
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");
            Vector3 movement = new Vector3(x, y, 0).normalized;
            Vector3 velocity = movement * speed * Time.deltaTime;
            transform.position += velocity;
        }
    }
}


