using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject panel;

    public void ClosePanel(){
        
    }

    public void ExitGame() {
        Application.Quit();
    }

    public void StartGame(){

        //SceneManager.LoadScene("Gameplay");
    }
    // Start is called before the first frame update
    
}
