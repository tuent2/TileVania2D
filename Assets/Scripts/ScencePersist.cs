using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScencePersist : MonoBehaviour
{
    private void Awake() {
        int numGamePersist = FindObjectsOfType<ScencePersist>().Length;
        if (numGamePersist > 1 ){
            Destroy (gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ResetGamePersist(){
        Destroy(gameObject);
    }
} 
