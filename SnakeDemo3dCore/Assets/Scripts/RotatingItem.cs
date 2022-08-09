using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingItem : MonoBehaviour
{
    public AudioSource audioSource;
    public float speed = 50.0f;

    

    // Start is called before the first frame update
    void Start()
    {
        //GameObject player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
    
    }


    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            GameObject player = GameObject.FindWithTag("Player");
            audioSource.Play();
            Player playerScript = player.GetComponent<Player>();
            playerScript.items++;
            //collider.gameObject.items++;
            //GetComponent(MeshRenderer).enabled = false;
            // float intermissionDelay = 0.3f;
            // WaitForSeconds waitTime = new WaitForSeconds(intermissionDelay);
            //Blink();
            Destroy(gameObject,1);
        }
    }
}
