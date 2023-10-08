using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemyPrefab1;
    public GameObject enemyPrefab2;
    public GameObject boss1Prefab; 
    private bool BossSpawned = false; // ボスが生成されたかどうかを示すフラグ

    public float delay = 0.1f;
    public int maxCount = 20;
    public int count;
    public int totalCount;
    private float timer;

    private Transform player;

    [SerializeField] private Transform center;
    [SerializeField] private float radius;
    [SerializeField] private float speed;
    private float angle;
    private Vector3 offset;

    void Start()
    {
        count = 0;
    }

    void Update()
    {
        angle += Time.deltaTime * speed;
        offset = new Vector3(Mathf.Sin(angle), Mathf.Cos(angle), 0) * radius;

        timer += Time.deltaTime;
        if(center != null)
        {
            Generator(delay, maxCount);

            if(totalCount > 10 && !BossSpawned)
            {
                GameObject boss1 = Instantiate(boss1Prefab, center.position + offset, Quaternion.identity);
                boss1.transform.SetParent(transform);
                BossSpawned = !BossSpawned;
            }
        }
    }

    void Generator(float delay, int maxCount)
    {
        if (timer > delay && count < maxCount)
        {
            if(Random.value < 0.3f)//30%0.3f
            {
                GameObject enemy2 = Instantiate(enemyPrefab2, center.position + offset, Quaternion.identity);
                enemy2.transform.SetParent(transform); // EnemyGeneratorの子に設定
            }
            else
            {
                GameObject enemy = Instantiate(enemyPrefab1, center.position + offset, Quaternion.identity);
                enemy.transform.SetParent(transform); // EnemyGeneratorの子に設定
            }
            timer = 0.0f;
            count++;
        }
    }
}
