using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class GameManager : MonoBehaviour
{
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
        //time since beginning
        //players position
        //object player collided with
        AnalyticsEvent.GameOver();
    }

    void Checkpoint()
    {
        //time since beginning
        //player health (before checkpoint health boost
    }
}
