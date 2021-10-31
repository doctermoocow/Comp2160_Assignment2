using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class GameManager : MonoBehaviour
{

    public Rigidbody player;
    public float playerHealth = 100;
    public float healthRestore = 50;
    public GameObject checkpoint;

    // Start is called before the first frame update
    void Start()
    {
        AnalyticsEvent.GameStart();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void GameOver()
    {
        AnalyticsEvent.GameOver();
    }

    void Checkpoint(GameObject checkpoint)
    {
        float TimeSinceStart = Time.realtimeSinceStartup;

        Analytics.CustomEvent("Checkpoint", new Dictionary<string, object>
        {
            {"Time since start of game:", TimeSinceStart},
            {"Player health:", playerHealth}
        });

        //playerHealth += healthRestore;

        /*
        if(checkpoint == lastCheckpoint)
        {
            GameOver();
        }
        */
    }

    void Death(GameObject causeOfDeath)
    {
        float TimeSinceStart = Time.realtimeSinceStartup;
        Vector3 playerPosition = player.transform.localPosition;

        Analytics.CustomEvent("Death", new Dictionary<string, object>
        {
            {"Time since start of game:", TimeSinceStart},
            {"Player position:", playerPosition},
            {"Cause of death:", causeOfDeath}
        });

        GameOver();
    }
}