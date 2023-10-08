using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneButton : MonoBehaviour
{
    public string SceneName;

    void Start()
    {
       GetComponent<Button>().onClick.AddListener(() =>
       {
            SceneManager.LoadScene(SceneName);
       });
    }

    void Update()
    {
        
    }
}
