using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Player : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent = null;

    public int items = 0;
    private bool alive = true;
    public AudioSource dieSound;
    public AudioSource victorySound;

    private GameObject shapeShifter;

    public bool winState;
    private float maxSpeed = 1000.0f;
    private float minSpeed = 0.0f;
    private float speed = 20.0f;
    public bool acelerating = true;
    public bool desAcelerating = false;

    void Start(){
        shapeShifter = this.gameObject.transform.GetChild(0).gameObject;
    }
    void Update()
    {
        if (items < 3 && alive){
            if (Input.GetMouseButtonDown(0)) {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    _agent.SetDestination(hit.point);
                }
            }
        }
        if (winState){
            if(acelerating){
                this.transform.Rotate(Vector3.up * speed * Time.deltaTime );
                speed += 5.0f;
                if (speed >= maxSpeed){
                    acelerating = false;
                    this.GetComponent<Renderer>().enabled = false;
                    shapeShifter.transform.position = this.transform.position;
                    //player.SetActive(false); 
                    shapeShifter.SetActive(true);
                    desAcelerating = true;
                }
            }
            if (desAcelerating){
                shapeShifter.transform.Rotate(Vector3.right * speed * Time.deltaTime );
                speed -= 5.0f;
                if (speed <= minSpeed){
                    desAcelerating = false;
                }
            }
        }
    }

    public void Die(){
        alive = false;
        this.GetComponent<NavMeshAgent>().enabled = false;
        dieSound.Play();
        StartCoroutine(Blink());
        Destroy(gameObject,3);
    }

    public void Win(){
        victorySound.Play();
        this.GetComponent<NavMeshAgent>().enabled = false;
    }

    private IEnumerator Blink(){
        while (true){
            this.GetComponent<Renderer>().enabled = false;
            yield return new WaitForSeconds(0.2f);
            this.GetComponent<Renderer>().enabled = true;
            yield return new WaitForSeconds(0.2f);
        }
    }

}
