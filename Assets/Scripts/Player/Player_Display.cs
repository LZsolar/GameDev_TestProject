using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player_Display : MonoBehaviour
{
    public Player_Status _playerStatus;

    public TextMeshProUGUI _PlayerHPdisplay,_PlayerAPdisplay;

    private void Start()
    {
       _playerStatus = GetComponent<Player_Status>();
    }

    void Update()
    {
        DisplayHP();
        DisplayAP();
    }
    public void DisplayHP()
    {
        _PlayerHPdisplay.text = "Player HP : " + _playerStatus.getPlayerHP();
    }
    public void DisplayAP()
    {
        _PlayerAPdisplay.text = "Player AP : " + _playerStatus.getPlayerAP();
    }
}
