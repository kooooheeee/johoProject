using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Penetration : MonoBehaviour
{
    //貫通弾のスクリプト
    public Transform FirePoint;
    public GameObject bulletPrefab;
    public int bulletSpeed = 1;
    public float delay = 0.2f;
    public Slider slider;

    private float timer;

    GameController GC;

    void Start()
    {
        GC = GameObject.Find("GameController").GetComponent<GameController>();
    }

    void Update()
    {
        // slider.maxValue = delay;
        // slider.value = timer;
        timer += Time.deltaTime;

        if (Input.GetMouseButton(0) && timer > delay)
        {
            FireBullet(); // 弾を発射する
            timer = 0.0f;
        }
    }

    void FireBullet()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - FirePoint.position).normalized;
            
        GameObject bullet = Instantiate(bulletPrefab, FirePoint.position, Quaternion.identity);
        bullet.transform.SetParent(GC.transform);
        bullet.transform.up = direction;

        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.velocity = direction.normalized * bulletSpeed;
    }  
}