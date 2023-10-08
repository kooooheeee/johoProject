using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealItem : MonoBehaviour
{
    PlayerControler player;
    public int healValue = 5;

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
            GameObject PlayerValue = Instantiate(textPrefab, player.transform.position, transform.rotation);
            PlayerValue.transform.SetParent(player.transform);
            TextMesh textMesh = PlayerValue.GetComponent<TextMesh>();
            textMesh.text = healValue.ToString();
            textMesh.color = Color.green;

            player.hp += healValue;
            if(player.hp > 20)
            {
                player.hp = 20;
            }
            Destroy(gameObject);
            Debug.Log(player.hp);
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
