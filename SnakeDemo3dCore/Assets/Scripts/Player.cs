using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Player : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent = null;

    public int items = 0;
    float maxSpeed = 300.0f;
    public float speed = 40.0f;
    bool acelerating = true;
    bool desAcelerating = false;
    // Update is called once per frame
    void Update()
    {
        if (items < 3){
            if (Input.GetMouseButtonDown(0)) {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    _agent.SetDestination(hit.point);
                }
            }
        }
        else {
            if (acelerating)
                StartCoroutine(Acelerate());
            
            if (desAcelerating){
                acelerating = false;
                this.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
                StopCoroutine(Acelerate());
                transform.Rotate(-Vector3.up * speed * Time.deltaTime );
                StartCoroutine(DesAcelerate());    
            }
        }
    }

    IEnumerator Acelerate()
    {
        if(acelerating){
            //yield return new WaitForSeconds(2);
            // if (speed >= maxSpeed)
            //     speed = maxSpeed;
            // else{
                transform.Rotate(Vector3.up * speed * Time.deltaTime );
                //yield return new WaitForSeconds(3);
                //desAcelerating = true;
                yield return new WaitForSeconds(1);
                if (speed < maxSpeed)speed += 1f;
                if (speed >= maxSpeed){
                    speed = maxSpeed;
                    yield return new WaitForSeconds(3);
                    acelerating = false;
                    desAcelerating = true;
                }
            //}
            //yield return new WaitForSeconds(3);
            //this.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
        }
        
        //transform.Rotate(Vector3.up * speed * Time.deltaTime );
        //yield return new WaitForSeconds(3);
    }

    IEnumerator DesAcelerate()
    {
        if (desAcelerating == true){
            transform.Rotate(-Vector3.up * speed * Time.deltaTime );
            yield return new WaitForSeconds(3);

            transform.Rotate(0,0,0);
            desAcelerating = false;
        }
        // while(desAcelerating){
        //     acelerating = false;
        //     //yield return new WaitForSeconds(2);
        //     transform.Rotate(-Vector3.up * speed * Time.deltaTime );
        //     yield return new WaitForSeconds(2);
        //     //speed = speed - 1f;
        //     //if(speed <= 0)
        //         //desAcelerating = false;
        //     //yield return new WaitForSeconds(2);
        // }
    }


}
