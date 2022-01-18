using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class MenuScripts : MonoBehaviour
{
    public string sceneToRun;
    
    public GameObject menuToHide;
    
    public void HideMenu()
    {
        menuToHide.SetActive(false);
    }

    public void RunScene()
    {
        SceneManager.LoadScene("Scenes/"+sceneToRun);
    }
   
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
