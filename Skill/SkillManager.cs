using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum SkillType
{
    ATTACK1,
    ATTACK2,
    ATTACK3,
    ATTACK4,
    WEAPON1,
    WEAPON2,
    WEAPON3,
    WEAPON4,
}

public class SkillManager : MonoBehaviour
{
    [SerializeField] Text skillPointText;
    [SerializeField] Text skillInfoText;
    [SerializeField] GameObject skillBlockPanel;

    List<SkillType> skillList = new List<SkillType>();
    SkillBlock[] skillBlocks;

    public static SkillManager instance;
    

    public PlayerControler playerControler;
    // public Penetration penetration;
    public Dog dog;

    public Weapon weapon;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        skillBlocks = skillBlockPanel.GetComponentsInChildren<SkillBlock>();
    }

    void Start()
    {
        // player = GameObject.Find("Player").GetComponent<PlayerControler>();
        // penetration = GameObject.Find("Player").GetComponent<Penetration>();
        // weapon = GameObject.Find("Player").GetComponent<Weapon>();
    }

    public bool HasSkill(SkillType skillType)
    {
        // 取得済みならtrue,まだならfalse
        return skillList.Contains(skillType);
    }

    public bool CanLearnSkill(SkillType skillType)
    {
        if(skillType == SkillType.WEAPON1)
        {
            return HasSkill(SkillType.ATTACK1);
        }
        if(skillType == SkillType.WEAPON2)
        {
            return HasSkill(SkillType.WEAPON1);
        }
        if(skillType == SkillType.WEAPON3)
        {
            return HasSkill(SkillType.WEAPON1) && HasSkill(SkillType.WEAPON2);
        }
        if(skillType == SkillType.ATTACK2)
        {
            return HasSkill(SkillType.ATTACK1);
        }
        if(skillType == SkillType.WEAPON4)
        {
            return HasSkill(SkillType.WEAPON1) && HasSkill(SkillType.WEAPON2);
        }
        if(skillType == SkillType.ATTACK3)
        {
            return HasSkill(SkillType.ATTACK1) && HasSkill(SkillType.ATTACK2);
        }
        if(skillType == SkillType.ATTACK4)
        {
            return HasSkill(SkillType.ATTACK3);
        }
        return true;
    }

    public void LearnSkill(SkillType skillType)
    {
        skillList.Add(skillType);
        CheackActiveBlocks();

        switch (skillType)
        {
            // WEAPON1パネル解放時にPenetrationスクリプトをONにする
            case SkillType.ATTACK1:
            weapon.atk += 10;
            break;

            case SkillType.ATTACK2:
            weapon.atk += 10;
            break;

            case SkillType.WEAPON1:
            dog.enabled = true;
            break;

            case SkillType.WEAPON2:
            dog.repeatCount++;
            break;

            case SkillType.WEAPON3:
            break;

            case SkillType.WEAPON4:
            break;

            default:
            break;
        }

        // if (skillType == SkillType.WEAPON1)
        // {

        // }
    }

    void CheackActiveBlocks()
    {
        foreach (SkillBlock skillBlock in skillBlocks)
        {
            skillBlock.CheackActiveBlock();
        }
    }
}
