using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingItem : MonoBehaviour
{
    public AudioSource audioSource;
    private float speed = 50.0f;
    private GameObject child;

    private bool rotating = true;

    // public bool blinking = false;
    
    void Start(){
        this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        child = this.gameObject.transform.GetChild(0).gameObject;//.SetActive(true);

    }

    void Update()
    {
        if(rotating)
            transform.Rotate(Vector3.up * speed * Time.deltaTime);
        else{
            child.transform.position += Vector3.up * 0.001f;
            
        }
        // if(blinking){
        //     StartCoroutine(Blink());
        // }
    }


    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            GameObject player = GameObject.FindWithTag("Player");
            audioSource.Play();
            rotating = false;
            child.SetActive(true);
            child.transform.rotation = Quaternion.Euler(0.0f, -60.0f, 0.0f);
            Player playerScript = player.GetComponent<Player>();
            playerScript.items++;
            // blinking = true;
            Destroy(gameObject,1);
        }
    }

    // IEnumerator Blink(){
    //     while (blinking){
    //         this.GetComponent<Renderer>().enabled = false;
    //         yield return new WaitForSeconds(0.4f);
    //         this.GetComponent<Renderer>().enabled = true;
    //     }
    // }
}
