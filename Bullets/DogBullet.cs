using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogBullet : MonoBehaviour
{
    public float lifeTime = 10f;
    public int atk;
    private int critical;
    public float bulletSpeed = 0;

    public GameObject textPrefab;
    private TextMesh text;

    EnemyGenerator enemyGenerator;
    Dog dog;

    void Start()
    {
        dog = GameObject.Find("Player").GetComponent<Dog>();
        enemyGenerator = GameObject.Find("EnemyGenerator").GetComponent<EnemyGenerator>();
        text = GetComponent<TextMesh>();
    }

    void Update()
    {
        transform.position += new Vector3 (bulletSpeed, 0, 0) * Time.deltaTime;
        Destroy(gameObject,lifeTime);
        atk = dog.atk;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Enemyスクリプトの参照を取得
            EnemyX enemy = collision.gameObject.GetComponent<EnemyX>();

            // ダメージ表示、体力処理
            GameObject EnemyDamage = Instantiate(textPrefab, enemy.transform.position, enemy.transform.rotation);
            TextMesh textMesh = EnemyDamage.GetComponent<TextMesh>();
            textMesh.text = atk.ToString();
            EnemyDamage.transform.SetParent(enemyGenerator.transform);

            // //クリティカル処理1%0.01f
            // if(Random.value < 0.5f)
            // {
            //     critical = atk * 2;
            //     enemy.Hp -= critical;
            //     textMesh.color = Color.yellow;
            //     textMesh.text = critical.ToString();
            // }
            // else
            // {
            //     enemy.Hp -= atk;
            // }
            
            enemy.Hp -= atk;
        }
    }
}
