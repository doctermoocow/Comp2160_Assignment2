using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public Rigidbody player;
    public float playerHealth = 100;
    public float playerSmoke = 50;
    public float healthRestore = 50;
    public float damageValue = 1;
    public GameObject checkpoint;
    public float checkpointRadius = 0.5f;

    private Dictionary<int, string> checkpointCompletion;

    // Start is called before the first frame update
    void Start()
    {
        AnalyticsEvent.GameStart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GameOver(bool died)
    {
        string gameOverText;
        checkpointCompletion = FindObjectOfType<CheckpointParent>().getCheckpointStatus();
        if (died)
        {
            gameOverText = "You died!";
        }
        else
        {
            gameOverText = "You win!";
        }
        FindObjectOfType<UIManager>().activateGameOverPanel(gameOverText, checkpointCompletion);
        AnalyticsEvent.GameOver();
    }

    public void Checkpoint(bool finalCheckpoint)
    {
        float currHealth = FindObjectOfType<PlayerHealth>().getHealth();
        string checkpointTime = FindObjectOfType<UIManager>().getTime();
        FindObjectOfType<PlayerHealth>().healthRestore();

        Analytics.CustomEvent("Checkpoint", new Dictionary<string, object>
        {
            {"Time since start of game:", checkpointTime},
            {"Player health:", currHealth}
        });

        if(finalCheckpoint)
        {
            GameOver(false);
        }
        
    }

    public void Death(string causeOfDeath)
    {
        string timeOfDeath = FindObjectOfType<UIManager>().getTime();
        Vector3 playerPosition = player.transform.localPosition;

        Analytics.CustomEvent("Death", new Dictionary<string, object>
        {
            {"Time since start of game:", timeOfDeath},
            {"Player position:", playerPosition},
            {"Cause of death:", causeOfDeath}
        });

        GameOver(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
