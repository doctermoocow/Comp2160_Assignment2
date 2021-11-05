using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class GameManager : MonoBehaviour
{

    public Rigidbody player;
    public float playerHealth = 100;
    public float healthRestore = 50;
    public float damageValue = 1;
    public GameObject checkpoint;
    public float checkpointRadius = 0.5f;

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
        if (died)
        {
            // You died text on ui
        }
        else
        {
            // Game won text on ui
        }
        // Make ui visible
        AnalyticsEvent.GameOver();
    }

    public void Checkpoint(float currHealth, bool lastCheckpoint)
    {
        float TimeSinceStart = Time.realtimeSinceStartup;

        Analytics.CustomEvent("Checkpoint", new Dictionary<string, object>
        {
            {"Time since start of game:", TimeSinceStart},
            {"Player health:", currHealth}
        });

        
        if(lastCheckpoint)
        {
            GameOver(false);
        }
        
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

        GameOver(true);
    }
}
