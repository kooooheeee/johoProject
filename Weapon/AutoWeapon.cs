using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoWeapon : MonoBehaviour
{
    public GameObject objectPrefab; // 発射するオブジェクトのプレハブ
    public float launchSpeed = 5.0f; // オブジェクトの発射速度
    public float launchInterval = 0.2f; // オブジェクトの発射間隔（秒）
    public int numberOfProjectiles = 12; // 発射するオブジェクトの数
    public float initialAngle = 0f; // 初期の発射角度

    void Start()
    {
        InvokeRepeating("StartLaunching", 0f, 3f);
    }

    void StartLaunching()
    {
        StartCoroutine(LaunchObjects());
    }

    IEnumerator LaunchObjects()
    {
        float angleStep = 360f / numberOfProjectiles; // 発射角度の増加量

        for (int i = 0; i < numberOfProjectiles; i++)
        {
            float angle = initialAngle + i * angleStep;
            Vector2 direction = Quaternion.Euler(0f, 0f, angle) * Vector2.right;
            GameObject launchedObject = Instantiate(objectPrefab, transform.position, Quaternion.identity);
            launchedObject.GetComponent<Rigidbody2D>().velocity = direction * launchSpeed;
            yield return new WaitForSeconds(launchInterval);
        }
    }

    // public GameObject objectPrefab; // 発射するオブジェクトのプレハブ
    // public float launchSpeed = 5.0f; // オブジェクトの発射速度
    // public float launchInterval = 0.2f; // オブジェクトの発射間隔（秒）
    // public float launchAngleRange = 90f; // 発射する角度範囲（度）

    // private Transform player; // プレイヤーのTransform

    // void Start()
    // {
    //     player = GameObject.FindGameObjectWithTag("Player").transform;
    //     // 発射処理を開始
    //     StartCoroutine(LaunchObjects());
    // }

    // IEnumerator LaunchObjects()
    // {
    //     while (true)
    //     {
    //         float angle = Random.Range(-launchAngleRange / 2f, launchAngleRange / 2f);
    //         Vector2 direction = Quaternion.Euler(0f, 0f, angle) * Vector2.right;
    //         GameObject launchedObject = Instantiate(objectPrefab, player.position, Quaternion.identity);
    //         launchedObject.GetComponent<Rigidbody2D>().velocity = direction * launchSpeed;
    //         yield return new WaitForSeconds(launchInterval);
    //     }
    // }
}
