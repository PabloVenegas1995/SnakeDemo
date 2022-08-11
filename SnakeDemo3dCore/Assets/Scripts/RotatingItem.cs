using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingItem : MonoBehaviour
{
    public AudioSource audioSource;
    private float speed = 50.0f;
    private GameObject child;

    private bool rotating = true;

    public bool blinking = false;
    
    void Start(){
        child = this.gameObject.transform.GetChild(0).gameObject;       
    }

    void Update()
    {
        if(rotating)
            transform.Rotate(Vector3.up * speed * Time.deltaTime);
        else{
            child.transform.position += Vector3.up * 0.001f;
            
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            this.GetComponent<Collider>().enabled = false;
            GameObject player = GameObject.FindWithTag("Player");
            audioSource.Play();
            rotating = false;
            child.SetActive(true);
            child.transform.rotation = Quaternion.Euler(0.0f, -60.0f, 0.0f);
            Player playerScript = player.GetComponent<Player>();
            playerScript.items++;
            blinking = true;
            StartCoroutine(Blink());
            Destroy(gameObject,1);
        }
    }

    private IEnumerator Blink(){
        while (blinking){
            this.GetComponent<Renderer>().enabled = false;
            yield return new WaitForSeconds(0.2f);
            this.GetComponent<Renderer>().enabled = true;
            yield return new WaitForSeconds(0.2f);
        }
    }
}
