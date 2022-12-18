using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playercollisions : MonoBehaviour
{
    public GameObject Fact1;
    public GameObject Fact2;

    public GameObject Chest;
    public GameObject Fire;

    int collisioncounter = 0;
    
    void Start()
    {
        Fact1.SetActive(false);
        Fact2.SetActive(false);
        //timer += Time.deltaTime;
    }

    void Show1(){
        Fact1.SetActive(true);
        Invoke("Hide1", 6f);
    }

    void Show2(){
        Fact2.SetActive(true);
        Invoke("Hide2", 6f);
    }

    void Hide1(){
        Fact1.SetActive(false);
    }

    void Hide2(){
        Fact2.SetActive(false);
    }
    
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Chest"){
            //Debug.Log("hit detected");
            //Fact1.SetActive(true);
            //GameObject e = Instantiate(Fact) as GameObject;
            
            Chest.SetActive(false);
            //DelayedStartCoroutine(Fact1, 5);
            Show1();
            //yield return new WaitForSeconds (6);
            //Fact1.SetActive(true);

        }
        
        if (coll.tag == "Fire"){
            collisioncounter++;

            if(collisioncounter>=3){
                Fire.SetActive(false);
                Show2();
                //Fact2.SetActive(true);
            } 
            
            //DelayedStartCoroutine(Fact2, 5);

            //Fact2.SetActive(true);
            //yield return new WaitForSeconds (6);
            
        }
    }

    /*private static IEnumerator DelayedStartCoroutine(GameObject target, float time)
    {
        if (target.activeInHierarchy) target.SetActive(true);
        yield return new WaitForSeconds(time);
        target.SetActive(false);
         
    }*/


    /*void OnCollisionEnter(UnityEngine.Collision collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Obstacle")
        {
            Debug.Log ("We hit something.");
        }
    }*/
}