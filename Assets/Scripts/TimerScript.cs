using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimerScript : MonoBehaviour
{

    public Text timerText;
    
    public GameObject winning_condition;
    public float timerValue = 120;



    // Update is called once per frame
    private void Start()
    {
        timerValue = winning_condition.GetComponent<WinningCondition1>().time_to_survive;
    }
    void Update()
    {
        if (timerValue > 0)
        {
            timerValue -= Time.deltaTime;
        }
        else
        {
            timerValue = 0;
        }

        DisplayTime(timerValue);
    
    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }
        else if (timeToDisplay > 0)
        {
            timeToDisplay += 1;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
