using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMovement : MonoBehaviour
{
    public GameObject player;
    private Transform playerPos;

    private Vector2 startPos;
    [SerializeField] float SpeedEnermy = 5;
    [SerializeField] float distance;
    bool isChasingPlayer = false;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerPos = player.GetComponent<Transform>();
        startPos = GetComponent<Transform>().position;
    }

    void Update()
    {
        // Moving Toward Player
        if(Vector2.Distance(transform.position, playerPos.position) < distance)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, SpeedEnermy * Time.deltaTime);
            if (!isChasingPlayer)
            {
                changeChasingStatus();
                noticePlayerCombatStatus();
            }
        }
        else
        {
            //Idle state
            if (Vector2.Distance(transform.position, startPos) <= 0)
            {
                
            }
            //Retreat
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, startPos, SpeedEnermy * Time.deltaTime);
                if (isChasingPlayer)
                {
                    changeChasingStatus();
                    noticePlayerCombatStatus();
                }
            }
        }
    }

    void noticePlayerCombatStatus()
    {
        player.GetComponent<Player_Status>().updateCombatStatus(isChasingPlayer);
    }
    void changeChasingStatus() { isChasingPlayer = !isChasingPlayer; }
}
