using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform groundCheck;

    [SerializeField] private LayerMask groundLayer;

    
    [SerializeField] public Sprite fire0;
    [SerializeField] public Sprite fire1;
    [SerializeField] public Sprite fire2;
    [SerializeField] public Sprite fire3;
    [SerializeField] public Sprite fire4;


    public GameObject projectile;
    public float position;

    private float timeBtwShots;
    public float startTimeBtwShots;
    /*
    // Start is called before the first frame update
    void Start()
    {
        
    }*/

    // Update is called once per frame

    void OnTriggerEnter2d(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DestroyFire();
        }
    }

    void DestroyFire()
    {
        Transform[] allChildren = GetComponentsInChildren<Transform>();  // collect entire sub-graph into array
        foreach(Transform t in allChildren) 
        {
            Destroy(t.gameObject);
        }

        //Destroy(gameObject);
    }

    void Update()
    {
        
        if (timeBtwShots <= 0){
            Instantiate(projectile, transform.position + new Vector3(position, 0f, 0f), Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
            
            if (this.gameObject.GetComponent<SpriteRenderer>().sprite == fire0){
                this.gameObject.GetComponent<SpriteRenderer>().sprite = fire1;
            }
            else if (this.gameObject.GetComponent<SpriteRenderer>().sprite == fire1){
                this.gameObject.GetComponent<SpriteRenderer>().sprite = fire2;
            }
            else if (this.gameObject.GetComponent<SpriteRenderer>().sprite == fire2){
                this.gameObject.GetComponent<SpriteRenderer>().sprite = fire0;
            }
            else if (this.gameObject.GetComponent<SpriteRenderer>().sprite == fire3){
                this.gameObject.GetComponent<SpriteRenderer>().sprite = fire4;
            }
            else if (this.gameObject.GetComponent<SpriteRenderer>().sprite == fire4){
                this.gameObject.GetComponent<SpriteRenderer>().sprite = fire0;
            }

        } else{
            timeBtwShots -= Time.deltaTime;
        }
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}
