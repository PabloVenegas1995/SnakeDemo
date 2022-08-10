using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Level : MonoBehaviour
{
    // Start is called before the first frame update
    private float timeLeft = 30.0f;
    public GameObject player;
    private Player playerScript;
    public GameObject shapeShifter;
    private GameObject playerActive;

    private float maxSpeed = 1000.0f;
    private float minSpeed = 0.0f;
    private float speed = 20.0f;
    public bool acelerating = true;
    public bool desAcelerating = false;
    
    //public bool gameplayState = false;

    public TMP_Text timerText;
    
    void Start()
    {
        playerScript = player.GetComponent<Player>();
        shapeShifter.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (playerScript.items < 3 && timeLeft > 0 )
            timeLeft -= Time.deltaTime;
        if (playerScript.items >= 3){
            GameWin();
            }
        timerText.text = timeLeft.ToString("F2");

        if(timeLeft <= 0){

            GameOver();
        }
    }

    void GameOver(){
            //audioSource.Play();
    }

    void GameWin(){
        StartCoroutine(SpinToWin());
        
        if (speed <= minSpeed){
            StopCoroutine(SpinToWin());
            //To win screen    
        }

        }
    IEnumerator SpinToWin(){
        if (acelerating)
            player.transform.Rotate(Vector3.up * speed * Time.deltaTime );
        if (desAcelerating)
            shapeShifter.transform.Rotate(Vector3.right * speed * Time.deltaTime );
        yield return new WaitForSeconds(2);
        if (acelerating)
            speed += 1.0f;
        if (speed >= maxSpeed){
            acelerating = false;
            player.GetComponent<Renderer>().enabled = false;
            shapeShifter.transform.position = player.transform.position;
            //player.SetActive(false); 
            shapeShifter.SetActive(true);

            desAcelerating = true;
        }
        yield return new WaitForSeconds(2);
        if (desAcelerating)
            speed -= 1.0f;
        if (speed <= minSpeed){
            desAcelerating = false;
            //this.GetComponent<Renderer>().enabled = false;
        }
    }
}
