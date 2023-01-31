using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManu : MonoBehaviour
{
   public string startLevel;
   public string levelSelect;
   public string signIn;

   public void NewGame()
   {
    SceneManager.LoadScene(startLevel);
   }
   public void SelectLevel()
   {
    SceneManager.LoadScene(levelSelect);
   }
   public void Quit()
   {
    Application.Quit();
   }
   public void SignIn()
   {
    SceneManager.LoadScene(signIn);
   }
}
