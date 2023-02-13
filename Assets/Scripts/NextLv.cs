 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextLv : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 2f;
    // Start is called before the first frame update
    

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player"){
            StartCoroutine(LoadNextLevel());
        }
         
    }

    IEnumerator LoadNextLevel(){
        yield return new WaitForSecondsRealtime(levelLoadDelay);
        int currentSenceIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSenceIndex = currentSenceIndex+1;
        if(nextSenceIndex == SceneManager.sceneCountInBuildSettings){
            nextSenceIndex = 0;
        }
        FindFirstObjectByType<ScencePersist>().ResetGamePersist();
        SceneManager.LoadScene(nextSenceIndex);
    }

    
}
