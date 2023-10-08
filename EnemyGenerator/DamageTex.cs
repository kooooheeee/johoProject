using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTex : MonoBehaviour
{
    //プレイヤーのAtkを取得してTextに代入
    private TextMesh text;
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector3(Random.Range(-80, 80), Random.Range(100, 180), 0));
        StartCoroutine(DestroyObject());
    }

    private IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(0.6f);
        Destroy(this.gameObject);
    }

    void Update()
    {
        
    }
}
