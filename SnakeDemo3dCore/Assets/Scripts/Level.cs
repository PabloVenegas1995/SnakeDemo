using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class Level : MonoBehaviour
{
    private float timeLeft = 33.0f;
    public GameObject player;
    private Player playerScript;
           
    public AudioSource alertSong;

    public TMP_Text timerText;

    private bool failState = false;
    private bool winState = false;

    public GameObject gameOver;

    
    void Start()
    {
        playerScript = player.GetComponent<Player>();
    }

    void Update()
    {
        if (playerScript.items < 3 && timeLeft > 0 )
            timeLeft -= Time.deltaTime;
        
        timerText.text = timeLeft.ToString("F2");
        
        if (playerScript.items >= 3 && !winState){
            GameWin();
            winState = true;
        }

        if(timeLeft <= 0 && !failState){
            failState = true;
            GameOver();
        }
    }

    void GameOver(){
        if (failState == true){
            alertSong.Stop();
            playerScript.Die();
            gameOver.SetActive(true);
        }
    }

    void GameWin(){
        
        alertSong.Stop();
        playerScript.winState = true;
        playerScript.Win();
        StartCoroutine(WaitForWin());
        }
    public void ExitGame() {
        Application.Quit();
    }
    public void RetryGame(){
        SceneManager.LoadScene("Gameplay");
    }
    private IEnumerator WaitForWin(){
        yield return new WaitForSeconds(6);
        SceneManager.LoadScene("WinMenu");
    }
}
