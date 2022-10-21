using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    //timer tutorial https://www.youtube.com/watch?v=27uKJvOpdYw
    private float timeDuration = 3f * 60;

    private float timer;

    [SerializeField]
    private TextMeshProUGUI firstMinute; //first slot for minutes
    [SerializeField]
    private TextMeshProUGUI secondMinute; //first slot for minutes
    [SerializeField]
    private TextMeshProUGUI separator; //first slot for minutes
    [SerializeField]
    private TextMeshProUGUI firstSecond; //first slot for minutes
    [SerializeField]
    private TextMeshProUGUI secondSecond; //first slot for minutes

    // Start is called before the first frame update
    void Start()
    {
        ResetTimer(); //reset timer on Start
        Debug.Log("The timer script has started.");
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0) //if the Timer amount is greater than 0, then...
        { 
            timer -= Time.deltaTime; //subtract amount of time that's elapsed between frames
            UpdateTimerDisplay(timer); //update the timer display with the new Time amount
            //Debug.Log("timer display ran");
        }
        else
        {
            Flash(); //call the flash warning function
        }
    }

    private void ResetTimer()
    {
        timer = timeDuration; //reset the timer to original amount of time

    }

    private void UpdateTimerDisplay (float time)
    {
        //Local Variables
        float minutes = Mathf.FloorToInt(time / 60); //60 seconds in a minute
                                                     //use FloortoInt to round the value down so that 0 actually equals 0
        //Debug.Log("minutes");
        float seconds = Mathf.FloorToInt(time % 60); //get what's left over after you divde by 60 after we get rid of all of the minutes

        string currentTime = string.Format("{00:00}{1:00}", minutes, seconds);
            //string.Replace?
        firstMinute.text = currentTime[0].ToString(); //convert the current time to a string, it's not changing the zero???
        secondMinute.text = currentTime[1].ToString();
        firstSecond.text = currentTime[2].ToString();
        secondSecond.text = currentTime[3].ToString();
    }

    private void Flash()
    {

    }
}
