using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAtkText : MonoBehaviour
{
    private TextMesh text;
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector3(Random.Range(-80, 80), Random.Range(100, 180), 0));
        StartCoroutine(DestroyObject());
        text = GetComponent<TextMesh>();
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
