using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUI : MonoBehaviour
{
    [SerializeField]private GameObject howToPlay;
    [SerializeField]private GameObject menu;
    
    public void OnStartClicked()
    {
        SceneManager.LoadScene("Scenes/GamePlay");
    }

    public void OnQuit()
    {
#if  UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    public void OnClickHowToPlay()
    {
        howToPlay.SetActive(true);
    }

    public void OnClickBack()
    {
        howToPlay.SetActive(false);

    }
}
