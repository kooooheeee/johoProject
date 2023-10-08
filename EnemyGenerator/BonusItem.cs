using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusItem : MonoBehaviour
{
    PlayerControler player;
    public int bonusValue = 5;

    public int lifeTime = 1;

    public float speed = 15f;
    public float stoppingDistance = 2f;

    public GameObject textPrefab;
    private TextMesh text;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerControler>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            GameObject PlayerBonusValue = Instantiate(textPrefab, player.transform.position, transform.rotation);
            PlayerBonusValue.transform.SetParent(player.transform);
            TextMesh textMesh = PlayerBonusValue.GetComponent<TextMesh>();
            textMesh.text = bonusValue.ToString();
            textMesh.color = Color.blue;

            player.armorHp += bonusValue;
            if(player.armorHp > 20)
            {
                player.armorHp = 20;
            }
            Destroy(gameObject);
        }

        //一定時間後に自身を破壊
        Destroy(gameObject,lifeTime);
    }

    private void Update()
    {
        if (player == null)
            return;

        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance > stoppingDistance)
        {
            // プレイヤーに向かって移動する
            Vector3 direction = (player.transform.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}
