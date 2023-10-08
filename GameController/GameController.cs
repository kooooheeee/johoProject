using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int resultScore = 0;
    public Text score;
    public Text timer;

    public GameObject RetryText;
    public GameObject SkillTree;
    public GameObject Menu;
    // public GameObject SkillPanel;
    public bool ClearFlag = false;
    private bool RetryFlag = false;
    private bool TabFlag = false;
    private bool MenuFlag = false;
    public bool levelUpFlag = false; 

    public PlayerControler player;
    
    private int minute = 5;
    private float seconds;
    private float oldSeconds;

    void Start()
    {
        RetryText.SetActive(RetryFlag);
        SkillTree.SetActive(TabFlag);
        Menu.SetActive(MenuFlag);
        seconds = minute * 60;
        // SoundManager.Instance.PlayBGM(BGMSoundData.BGM.Game);
    }

    void Update()
    {

        //スコア表示
        score.text = "Score : " + resultScore;

        //リトライ表示
        if(player == null && !RetryFlag)
        {
            RetryFlag = true;
            RetryText.SetActive(RetryFlag);
        }

        // スキル表示
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            TabFlag = !TabFlag;
            SkillTree.SetActive(TabFlag);
        }
        

        //Timer処理
        if(player != null)
        {
            seconds -= Time.deltaTime;
            var span = new TimeSpan(0, 0, (int)seconds);
            timer.text = span.ToString(@"mm\:ss");
        }

        // Menu表示
        if(Input.GetKeyDown(KeyCode.Escape) && !RetryFlag && !levelUpFlag)
        {
            MenuFlag = !MenuFlag;
        }
        Menu.SetActive(MenuFlag);
        if(MenuFlag)
        {
            SetTimeScale();
        }
        else
        {
            SetTimeScale();
        }

        // レベルアップ処理
        if(levelUpFlag)
        {
            SetTimeScale();
        }
        else
        {
            SetTimeScale();
        }
        // SkillPanel.SetActive(levelUpFlag);
        SkillTree.SetActive(levelUpFlag);

        // クリア処理
        if(ClearFlag)
        {
            Time.timeScale = 0;
            RetryFlag = true;
            RetryText.SetActive(RetryFlag);
        }

    }

    void SetTimeScale()
    {
        if (MenuFlag || levelUpFlag)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void MenuBack()
    {
        MenuFlag = !MenuFlag;
    }

    public void SelectSkill()
    {
        levelUpFlag = !levelUpFlag;
    }
}
