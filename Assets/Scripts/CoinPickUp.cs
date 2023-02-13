using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [SerializeField] AudioClip coinFixUpSFX;
    [SerializeField] int pointForPickUpCoin = 1;

    bool wasCollected = false;
    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player" && !wasCollected){
            wasCollected = true;
            FindObjectOfType<GameSession>().AddToScore(pointForPickUpCoin);
            AudioSource.PlayClipAtPoint(coinFixUpSFX, Camera.main.transform.position );
            gameObject.SetActive(false);
            Destroy(gameObject); 
        }   
    }
}
