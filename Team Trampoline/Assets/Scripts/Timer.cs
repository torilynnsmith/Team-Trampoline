using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    //timer tutorial https://www.youtube.com/watch?v=27uKJvOpdYw
    private float timeDuration = 1f * 60; //3minuts

    [SerializeField]
    private bool countDown = true; //allows us to change the timer from a count"down" to a count"up to". 

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

    private float flashTimer;
    private float flashDuration = 1f;

    // Start is called before the first frame update
    void Start()
    {
        ResetTimer(); //reset timer on Start
        Debug.Log("The timer script has started.");
    }

    // Update is called once per frame
    void Update()
    {
        if(countDown && timer > 0) //if the Timer amount is greater than 0, then...
        { 
            timer -= Time.deltaTime; //SUBTRACT amount of time that's elapsed between frames
            UpdateTimerDisplay(timer); //update the timer display with the new Time amount
            //Debug.Log("timer display ran");
        }
        else if(!countDown && timer < timeDuration)
        {
            timer += Time.deltaTime; //ADD amount of time that's elapsed between frames
            UpdateTimerDisplay(timer); //update the timer display with the new Time amount
        }
        else
        {
            Flash(); //call the flash warning function
        }
    }

    private void ResetTimer()
    {
        if(countDown) //if a count down...
        {
            timer = timeDuration; //reset the timer to original amount of time
        }
        else //if a count-up...
        {
            timer = 0; 
        }
        SetTextDisplay(true);
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
        if(countDown && timer != 0) //if countDown is checked 
        {
            timer = 0;
            UpdateTimerDisplay(timer);
        }

        if (!countDown && timer != timeDuration) //if countDown is NOT checked 
        {
            timer = 0;
            UpdateTimerDisplay(timer);
        }

        if (flashTimer <= 0)
        {
            flashTimer = flashDuration;

        }
        else if(flashTimer >= flashDuration/2)
        {
            flashTimer -= Time.deltaTime;
            SetTextDisplay(false); //turn display off
        }
        else
        {
            flashTimer -= Time.deltaTime;
            SetTextDisplay(true); //turn display on
        }
    }

    private void SetTextDisplay(bool enabled)
    {
        firstMinute.enabled = enabled;
        secondMinute.enabled = enabled;
        separator.enabled = enabled;
        firstSecond.enabled = enabled;
        secondSecond.enabled = enabled;
    }
}
