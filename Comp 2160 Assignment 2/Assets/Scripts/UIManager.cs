using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Text timer;
    private float countingTime;
    private int sec;
    private int min;
    private int hund;
    private string secText;
    private string hundText;
    private string timeFormatText;

    public GameObject gameOverPanel;
    public Text gameOverText;
    public Text checkpointsText;

    // Start is called before the first frame update
    void Start()
    {
        min = 0;
        sec = 0;
        hund = 0;

        gameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        countingTime += Time.deltaTime;

        if(countingTime / 0.01 >= 1)
        {
            hund += 1;
            countingTime = 0;
        }

        if(hund >= 100)
        {
            sec += 1;
            hund = 0;
        }

        if(sec >= 60)
        {
            min += 1;
            sec = 0;
        }

        if(sec < 10)
        {
            secText = "0" + sec.ToString();
        }
        else
        {
            secText = sec.ToString();
        }

        if (hund < 10)
        {
            hundText = "0" + hund.ToString();
        }
        else
        {
            hundText = hund.ToString();
        }

        timeFormatText = min.ToString() + ":" + secText + ":" + hundText;

        timer.text = timeFormatText;
    }

    public string getTime()
    {
        return timeFormatText;
    }

    public void activateGameOverPanel(string winOrDied, Dictionary<int, string> checkpointStatus)
    {
        string checkpointTextString = "";
        gameOverText.text = winOrDied;
        for(int i = 0; i < checkpointStatus.Count; i++)
        {
            checkpointTextString = checkpointTextString + "Checkpoint " + 
                (i+1).ToString() + ": " + checkpointStatus[i] + "\n";
        }
        checkpointsText.text = checkpointTextString;
        gameOverPanel.SetActive(true);
    }
}
