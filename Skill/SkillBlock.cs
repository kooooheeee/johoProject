using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillBlock : MonoBehaviour
{
    
    [SerializeField] SkillType skillType; 
    // [SerializeField] new string name;
    // [SerializeField] string info;
    [SerializeField] GameObject hidePanel;

    GameController gameController;

    void Start()
    {
        CheackActiveBlock();
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    public void OnClick()
    {
        //習得済みなら何もしない
        if(SkillManager.instance.HasSkill(this.skillType))
        {
            Debug.Log("習得済");
            return;
        }
        //習得可能？
        if(SkillManager.instance.CanLearnSkill(skillType))
        {
            //習得可能なら習得：スキルポイント＆必要スキルを持ってる
            SkillManager.instance.LearnSkill(this.skillType);
            Debug.Log("習得!");
            gameController.levelUpFlag = false;
            ChangeColor(Color.blue);
        }
        else
        {
            //習得不可ならログを出す
            Debug.Log("習得不可");
        }
    }

    public void CheackActiveBlock()
    {
        if(SkillManager.instance.CanLearnSkill(skillType))
        {
            //スキル取得可能なら黒パネルを消す
            hidePanel.SetActive(false);
        }
        else
        {
            //スキル取得不可なら黒パネルを出す
            hidePanel.SetActive(true);
        }
    }

    void ChangeColor(Color color)
    {
        Image image = GetComponent<Image>();
        image.color = color;
    }
}
