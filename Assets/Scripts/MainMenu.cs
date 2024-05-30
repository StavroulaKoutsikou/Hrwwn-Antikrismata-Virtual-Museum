using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  public void PlayGame()
  {
    SceneManager.LoadSceneAsync(1);
  }

    public void PlayEscapeRoom()
  {
    SceneManager.LoadSceneAsync(2);
  }

  public void QuitGame()
  {
    Application.Quit();
  }

  public void PlayQuizGame()
  {
    SceneManager.LoadSceneAsync(3);
  }

}
