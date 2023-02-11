using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemymove : MonoBehaviour
{
    [SerializeField] float enemyMoveSpeed = 3f;
    Rigidbody2D enemyRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        enemyRigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyRigidbody.velocity = new Vector2(enemyMoveSpeed, 0f);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        enemyMoveSpeed = -enemyMoveSpeed;
        FlipEnemyFacing();
    }
 
    void FlipEnemyFacing()
    {

        transform.localScale = new Vector2 (-(Mathf.Sign(enemyRigidbody.velocity.x)),1f);

    }
}
