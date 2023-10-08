using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KuruKuruBullet : MonoBehaviour
{
    // プレイヤーの周りを回る動き
    public float radius = 3.0f;      // 円の半径
    public float speed = 1.0f;       // 円を描く速度
    private float angle = 0.0f;      // 角度

    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // 円の動作
        angle -= speed * Time.deltaTime; // 角度を減少させることで右回転
        float x = player.position.x + radius * Mathf.Cos(angle);
        float y = player.position.y + radius * Mathf.Sin(angle);
        transform.position = new Vector3(x, y);

        // 猫の進行方向を向く
        // プレイヤーの方向に顔を向ける
        Vector3 direction = player.position - transform.position;
        float angleDegrees = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angleDegrees - 90f + 180f));
    }
}
