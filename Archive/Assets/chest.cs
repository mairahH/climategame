using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chest : MonoBehaviour
{

    //[SerializeField] private Rigidbody2D rb;
     public GameObject fact;
    private Transform player;
    private Vector2 target;

    private float position =0f;
    //[SerializeField] private LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
     player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector2(player.position.x, player.position.y);   
    }

    // Update is called once per frame
    void Update()
    {
        target = new Vector2(player.position.x, player.position.y);
        //transform.position = target.position;

        if(transform.position.x == target.x && transform.position.y == target.y)
        {
            //Destroy();
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        Instantiate(fact, transform.position + new Vector3(position, 0f, 0f), Quaternion.identity);
    }

}
