using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
  public void OnResume()
  {
    Time.timeScale = 1;
    OnHide();
  }

  public void OnQuit()
  {
#if  UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
  }

  public void OnRestart()
  {
    SceneManager.LoadScene("Scenes/GamePlay");
    Time.timeScale = 1; 
  }

  public void OnMainMenuClicked()
  {
    SceneManager.LoadScene("Scenes/StartScene");
    Time.timeScale = 1; 
  }
  private void OnHide()
  {
    gameObject.SetActive(false);
  }
}
