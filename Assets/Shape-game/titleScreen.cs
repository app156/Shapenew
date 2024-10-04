using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class titleScreen : MonoBehaviour
{
   
    public void sceneswitch(int scenenew)
    {
        SceneManager.LoadScene(scenenew);
        UIManger.Instance.playercontrol.enabled = true;
    }
    
    public void GameSceneExit()
    {
        Application.Quit();
        
    }
  
   
}
