using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Auto2 : MonoBehaviour
{
    public GameObject bulletPrefab; // 弾のプレハブ
    public int numberOfBullets = 12; // 発射する弾の数
    public float launchSpeed = 10.0f; // 弾の発射速度

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 全方向に弾を発射
            LaunchBullets();
        }
    }

    void LaunchBullets()
    {
        Vector2 playerPosition = transform.position; // プレイヤーの位置を取得
        float angleStep = 360f / numberOfBullets; // 弾の発射角度の増加量

        for (int i = 0; i < numberOfBullets; i++)
        {
            float angle = i * angleStep; // 弾の発射角度を計算
            Vector2 direction = Quaternion.Euler(0f, 0f, angle) * Vector2.up; // 弾の発射方向を計算

            // 弾を生成して発射
            GameObject bullet = Instantiate(bulletPrefab, playerPosition, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = direction * launchSpeed;
        }
    }
}
