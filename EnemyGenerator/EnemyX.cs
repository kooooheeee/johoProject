using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyX : MonoBehaviour
{
    public int enemyScore = 100;
    public int Hp = 10;
    public int Eatk = 10;
    private int critical;

    public float moveSpeed = 5f;
    public int hidari;

    //Playerから情報取得
    PlayerControler player;
    
    //enemyGeneratorから取得
    EnemyGenerator enemyGenerator;
    GameController gameController;

    //回復アイテムの情報
    public GameObject healItem;
    public GameObject bonusItem;
    public GameObject exp;
   

    // Textオブジェクト
    public GameObject textPrefab;
    private TextMesh text;


    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerControler>();
        enemyGenerator = GameObject.Find("EnemyGenerator").GetComponent<EnemyGenerator>();
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        text = GetComponent<TextMesh>();
    }

    void Update()
    {
        //Playerがいるなら追尾
        if(player != null && !gameController.ClearFlag)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
            if(hidari > 0)
            {
                transform.localScale = (transform.position.x < player.transform.position.x) ? new Vector3(-1, 1, 1) : new Vector3(1, 1, 1);
            }
            else
            {
                transform.localScale = (transform.position.x < player.transform.position.x) ? new Vector3(1, 1, 1) : new Vector3(-1, 1, 1);
            }
        }

        //破壊とカウント
        if(Hp<=0 && player != null)
        {
            Destroy(gameObject);
            enemyGenerator.count--;
            enemyGenerator.totalCount++;
            gameController.resultScore += enemyScore;

            GameObject Exp = Instantiate(exp, transform.position, transform.rotation);
            Exp.transform.SetParent(enemyGenerator.transform);

            if(gameObject.tag == "Boss")
            {
                gameController.ClearFlag = true;
            }

            //10%0.1fでアイテムをドロップ(Random.valueは0以上1未満)
        //     if (Random.value <= 0.1f)
        //     {
        //         GameObject HealItem = Instantiate(healItem, transform.position, transform.rotation);
        //         HealItem.transform.SetParent(enemyGenerator.transform);
        //     } 
        //     if(Random.value <= 0.1f)
        //     {
        //         GameObject BonusItem = Instantiate(bonusItem, transform.position, transform.rotation);
        //         BonusItem.transform.SetParent(enemyGenerator.transform);
        //     }
        } 
    }

    //Playerとの衝突処理
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //プレイヤーとの処理
        if(collision.gameObject.CompareTag("Player"))
        {
            //2秒経たないと実行されない
            if(player.PlayerTimer > 2)
            {
                SoundManager.Instance.PlaySE(SESoundData.SE.Attack);
                if(player.armorHp > 0)   
                {
                    player.armorHp -= Eatk;
                    if(player.armorHp < 0)
                    {
                        player.hp += player.armorHp;
                        player.armorHp = 0;
                    }
                }
                else
                {
                    player.hp -= Eatk;
                }  
                GameObject PlayerDamage = Instantiate(textPrefab, player.transform.position, transform.rotation);
                TextMesh textMesh = PlayerDamage.GetComponent<TextMesh>();
                textMesh.text = Eatk.ToString();
                PlayerDamage.transform.SetParent(enemyGenerator.transform);
                textMesh.color = Color.red;
                player.PlayerTimer = 0;
                Debug.Log("HP:" + player.hp);
                Debug.Log("Armor:" + player.armorHp);
            }
        }
    }
}