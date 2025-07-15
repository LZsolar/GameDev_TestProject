using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCotroller : MonoBehaviour
{

    [SerializeField] int _InGameDayCount = 0;
    string[] Day_Name = { "MON", "TUE", "WED", "THU", "FRI", "SAT", "SUN" };
    
    [SerializeField] int currentTime = 0;
    int _TimeOfTheDay = 0; //0 = Morning, 1 = Afternoon, 2 = Evening
    string[] Time_Name = { "Morning","Afternoon","Evening" };

    public void setTime(int TimeToChange)
    {
        if(TimeToChange < currentTime) { _InGameDayCount++; }
        currentTime = TimeToChange;
    }

    public string GetTimeOfTheDay()
    {
        return Time_Name[currentTime];
    }

    public string GetDayOfTheWeek()
    {
        return Day_Name[(_InGameDayCount%7)];
    }
    public int GetDayCount()
    {
        return _InGameDayCount;
    }



    // ForTest
    private void Update()
    {
        if(Input.GetKeyDown("1")) { setTime(0);  }
        if (Input.GetKeyDown("2")) { setTime(1); }
        if (Input.GetKeyDown("3")) { setTime(2); }

    }
}
