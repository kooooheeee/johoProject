using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    //連射弾のスクリプト
    public Transform FirePoint;
    public GameObject bulletPrefab;
    public int bulletSpeed = 1;
    public float delay = 0.2f;
    public int atk = 5;

    //弾倉の数を設定
    public int magazine;
    public int maxMagazine = 5;
    private float reloadTimer;
    public float reloadTime = 2;
    public float away = 0.5f;
    private bool isReloading = false;
    
    //Slider型はtrue or falseで制御できない、GameObject型も必要。
    public Slider reloadSrider;
    public GameObject reloadUI;

    private float timer;

    GameController GC;

    void Start()
    {
        GC = GameObject.Find("GameController").GetComponent<GameController>();
        magazine = maxMagazine; 
        reloadSrider.maxValue = reloadTime;
    }

    void Update()
    {
        timer += Time.deltaTime;

        reloadSrider.value = reloadTimer;
        reloadUI.SetActive(isReloading);

        if(magazine != 0)
        {
            if (Input.GetMouseButton(0) && timer > delay && Time.timeScale == 1)
            {
                isReloading = false;
                FireBullet();
                timer = 0.0f;
                reloadTimer = 0.0f;
                magazine--;
            }
        }
        else
        {
            isReloading = true;
        }

        if (timer > away && !isReloading && magazine != maxMagazine)
        {
            reloadTimer = 0.0f;
            isReloading = true;
        }

        if (isReloading)
        {
            reloadTimer += Time.deltaTime;
            
            if (reloadTimer > reloadTime)
            {
                magazine = maxMagazine;
                isReloading = false; // リロードが完了したらリロードフラグを解除
            }
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