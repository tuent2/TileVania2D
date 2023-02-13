using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    [SerializeField] int score = 0;
    [SerializeField] TextMeshProUGUI liveText;
    [SerializeField] TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    private void Awake() {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numGameSessions > 1 ){
            Destroy (gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ProcessPlayerDeath(){
        if(playerLives>1){
            TakeLife();
        }
        else {
            ResetGameSession();
        }
    }

    public void AddToScore(int point){
        score += point;
        scoreText.text = score.ToString(); 
    }

    void TakeLife()
    {
        playerLives--;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        liveText.text = playerLives.ToString(); 
    }

    private void Start() {
        liveText.text = playerLives.ToString(); 
        scoreText.text = score.ToString(); 
    }

    void ResetGameSession()
    {
        FindFirstObjectByType<ScencePersist>().ResetGamePersist();
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
