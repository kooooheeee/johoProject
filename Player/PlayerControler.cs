using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControler : MonoBehaviour
{
    //1．上下左右移動の速度設定
    public float speed = 1f;

    public int maxHp = 20;
    public int hp;
    public int armorHp;

    //体力表示用
    public Slider hpSlider;
    public Slider armorSlider;
    public float PlayerTimer;

    // 経験値
    public int level = 1;
    public int exp;
    public int maxExp = 20;
    public Slider expSlider;
    public GameController gameController;
    public Text levelText;

    // Atk addAtk;//(スクリプト名 + 入れ物の名前)

    private Animator anim;

    

    void Start()
    {
        hpSlider.maxValue = maxHp;
        armorSlider.maxValue = maxHp; 
        hp = maxHp;
        anim = GetComponent<Animator>();
        // gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    
    void Update()
    {
        //1．上下左右の移動
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector3 movement = new Vector3(x, y, 0).normalized;
        Vector3 velocity = movement * speed * Time.deltaTime;
        transform.position += velocity;

        //2．マウスカーソルの方向を向く
        /*var pos = Camera.main.WorldToScreenPoint (transform.localPosition);
        var rotation = Quaternion.LookRotation(Vector3.forward, Input.mousePosition - pos );
        transform.localRotation = rotation;*/


        //4. 体力処理
        hpSlider.value = hp;
        PlayerTimer += Time.deltaTime;
        armorSlider.value = armorHp;
        if(hp <= 0)
        {
            Destroy(gameObject);
        }

        //5. アニメーション処理
        if(!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
        {
           anim.SetBool("run", false);
        }
        else
        {
            if(x > 0)
            {
                anim.SetBool("run", true);
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if(x < 0)
            {
                anim.SetBool("run", true);
                transform.localScale = new Vector3(-1, 1, 1);
            } 
        }
        
        // else
        // {
        //     anim.SetBool("run", false);
        // }

        // Exp処理
        expSlider.maxValue = maxExp;
        expSlider.value = exp;
        if(exp >= maxExp)
        {
            SoundManager.Instance.PlaySE(SESoundData.SE.LevelUp);
            gameController.levelUpFlag = true;
            level += 1;
            exp = 0;
            maxExp += level * 3;
        }
        levelText.text = "level : " + level;
        // レベルアップ処理Debug用
        if(Input.GetKey(KeyCode.F))
        {
            exp += 1; 
        }
    }
}
