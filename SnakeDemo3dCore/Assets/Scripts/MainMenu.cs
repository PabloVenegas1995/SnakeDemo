using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject panel;

    private Animator anim;

    void Start()
    {
        anim = panel.GetComponent<Animator>();
    }


    public void ExitGame() {
        Application.Quit();
    }

    public void StartGame(){
        if (anim != null){
                anim.enabled = true;
        }
        StartCoroutine(WaitForPlay());
    }
    private IEnumerator WaitForPlay(){
        panel.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Gameplay");
        
    }
}
