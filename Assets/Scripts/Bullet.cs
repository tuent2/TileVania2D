using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D myRigidBody;
    PlayerMove player;
    float xSpeed;
    [SerializeField] float bulletSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = gameObject.GetComponent<Rigidbody2D>();
        player = FindAnyObjectByType<PlayerMove>();
        xSpeed = player.transform.localScale.x * bulletSpeed;
    }

    // Update is called once per frame
    void Update() 
    {
        myRigidBody.velocity = new Vector2(xSpeed,0f); 

        bool isMoveShoting = Mathf.Abs(player.transform.localScale.x) > Mathf.Epsilon;
        if(isMoveShoting){
            transform.localScale = new Vector2(Mathf.Sign(player.transform.localScale.x),1f);
        }
        myRigidBody.velocity = new Vector2(xSpeed,0f); 
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Enemy" ){
            Destroy(other.gameObject);
            
        }
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D other) {
        Destroy(gameObject);
    }
}
