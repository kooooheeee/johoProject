using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp : MonoBehaviour
{
    PlayerControler player;

    public float detectionDistance = 4.0f; // アイテムがPlayerを検出する距離
    public float moveSpeed = 3.0f; // 移動速度

    private Transform playerPos;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerControler>();
        playerPos = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        if (player != null)
        {
            // プレイヤーとアイテムの距離を計算
            float distanceToPlayer = Vector3.Distance(transform.position, playerPos.position);

            // 一定の距離未満であればPlayerに向かって移動
            if (distanceToPlayer <= detectionDistance)
            {
                Vector3 direction = (playerPos.position - transform.position).normalized;
                transform.position += direction * moveSpeed * Time.deltaTime;
            }
        }
    }

    //Playerとの衝突処理
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //プレイヤーとの処理
        if(collision.gameObject.CompareTag("Player"))
        {
            SoundManager.Instance.PlaySE(SESoundData.SE.Exp);
            player.exp += 1;
            Destroy(gameObject);
        }
    }
}
