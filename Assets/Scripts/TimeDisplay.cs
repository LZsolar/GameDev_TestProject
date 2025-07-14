using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeDisplay : MonoBehaviour
{
    public TimeCotroller _TimeController;

    public TextMeshProUGUI _InGameDayDisplay, _DayofTheWeekDisplay, _TimeOfTheDayDisplay;

    private void Start()
    {
        _TimeController = GetComponent<TimeCotroller>();
    }

    void Update()
    {
        DisplayInGameDayCount();
        DisplayTimeOfTheDay();
        DisplayDayOfTheWeek();
    }
    public void DisplayInGameDayCount()
    {
        _InGameDayDisplay.text = "Day Count : " + _TimeController.GetDayCount();
    }
    public void DisplayTimeOfTheDay()
    {
        _TimeOfTheDayDisplay.text = "Current Time : " + _TimeController.GetTimeOfTheDay();
    }
    public void DisplayDayOfTheWeek()
    {
        _DayofTheWeekDisplay.text = "Current Date : " + _TimeController.GetDayOfTheWeek();
    }
}
