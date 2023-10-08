using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletx : MonoBehaviour
{
    public float lifeTime = 10f;
    private int atk;
    private int critical;

    public GameObject textPrefab;
    private TextMesh text;

    EnemyGenerator enemyGenerator;
    Weapon weapon;

    void Start()
    {
        weapon = GameObject.Find("Player").GetComponent<Weapon>();
        enemyGenerator = GameObject.Find("EnemyGenerator").GetComponent<EnemyGenerator>();
        text = GetComponent<TextMesh>();
    }
    
    void Update()
    {
        Destroy(gameObject,lifeTime);

        atk = weapon.atk;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Boss"))
        {
            // 効果音
            SoundManager.Instance.PlaySE(SESoundData.SE.Attack);
            
            // Enemyスクリプトの参照を取得
            EnemyX enemy = collision.gameObject.GetComponent<EnemyX>();

            // ダメージ表示、体力処理
            GameObject EnemyDamage = Instantiate(textPrefab, enemy.transform.position, enemy.transform.rotation);
            TextMesh textMesh = EnemyDamage.GetComponent<TextMesh>();
            textMesh.text = atk.ToString();
            EnemyDamage.transform.SetParent(enemyGenerator.transform);

            //クリティカル処理1%0.01f
            if(Random.value < 0.5f)
            {
                critical = atk * 2;
                enemy.Hp -= critical;
                textMesh.color = Color.yellow;
                textMesh.text = critical.ToString();
            }
            else
            {
                enemy.Hp -= atk;
            }
        }
    }
}
