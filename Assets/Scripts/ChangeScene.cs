using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class ChangeScene : MonoBehaviour
{
    //reference video: https://www.youtube.com/watch?v=TVSLCZWYL_E 
    
   public string scene;

    // Update is called once per frame
    public void SelectScene()
    {
        SceneManager.LoadScene(scene);
    }


}
