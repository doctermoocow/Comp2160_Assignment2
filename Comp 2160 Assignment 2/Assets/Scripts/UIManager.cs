using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Text timer;
    private float minutes;
    private float seconds;
    private float hundredths;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        seconds = (Mathf.Round(Time.realtimeSinceStartup * 1.0f) * 1f)%60;
        //timer.text = ((Mathf.Round(Time.realtimeSinceStartup * 100.0f) * 0.01f)%60).ToString();
        timer.text = seconds.ToString();
    }
}
