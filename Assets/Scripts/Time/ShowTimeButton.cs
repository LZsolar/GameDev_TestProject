using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTimeButton : MonoBehaviour
{
    public GameObject ConfirmButton;
    [SerializeField] int TimeToChange = 0;
    public TimeCotroller _TimeController;
    bool isPlayerInside = false;

    void OnTriggerEnter2D(Collider2D col)
    {
       if(col.gameObject.tag == "Player")
        {
            ShowConfirmButton(); isPlayerInside = true;
        }
    }

    private void Update()
    {
        if(isPlayerInside && Input.GetKeyDown(KeyCode.E))
        {
            _TimeController.setTime(TimeToChange);
        }
    }


    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            HideConfirmButton(); isPlayerInside = false;
        }
    }


    public void ShowConfirmButton(){ConfirmButton.SetActive(true);}
    public void HideConfirmButton() { ConfirmButton.SetActive(false); }

}
