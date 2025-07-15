using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTimeButton : MonoBehaviour
{
    public GameObject ConfirmButton;
    [SerializeField] int TimeToChange = 0;
    public TimeCotroller _TimeController;


    void OnCollisionEnter2D(Collision2D collision)
    {
        print("YAHOOO");
       if(collision.gameObject.tag == "Player")
        {
            ShowConfirmButton();
            print("Enter!");
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player"&&Input.GetKeyDown(KeyCode.E))
        {
            _TimeController.setTime(TimeToChange);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            HideConfirmButton();
        }
    }


    public void ShowConfirmButton(){ConfirmButton.SetActive(true);}
    public void HideConfirmButton() { ConfirmButton.SetActive(false); }

}
