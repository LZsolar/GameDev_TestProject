using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMovement : MonoBehaviour
{
    public GameObject player;
    private Transform playerPos;
    Rigidbody2D rb;

    private Vector2 startPos;

    [SerializeField] float distance;
    public float moveSpeed = 5f;
    public float chaseRange = 15f;
    public float attackRange = 10f;
    public float attackSpeed = 3f;

    [Header("Attack Status")]
    bool isChasingPlayer = false;
    bool isPrepareToAttack = false;
    bool isAttacking = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = GetComponent<Transform>().position;
        player = GameObject.FindWithTag("Player");
        playerPos = player.GetComponent<Transform>();
    }

    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(transform.position, playerPos.position);
        if (distanceFromPlayer <= attackRange &&!isPrepareToAttack && !isAttacking) {
            noticePlayerCombatStatus(true);
            StartCoroutine(PrepareCharge());
        }
        // Moving Toward Player
        else if (distanceFromPlayer <= chaseRange && !isPrepareToAttack && !isAttacking)
        {
            noticePlayerCombatStatus(true);
            ChasePlayer();
            isChasingPlayer = true;
        }
        else if(distanceFromPlayer>chaseRange)
        {
             backToSpawn();
             noticePlayerCombatStatus(false);
             isChasingPlayer=false;
        }
    }

    private IEnumerator PrepareCharge()
    {
        isPrepareToAttack = true;
        moveSpeed = 0f;
        rb.velocity = Vector2.zero;

        Vector2 toPlayerDir = (playerPos.position - transform.position).normalized;
        Vector2 jumpTarget = (Vector2)transform.position + toPlayerDir * 2f;

        yield return new WaitForSeconds(2f); 

        isPrepareToAttack = false;
        isAttacking = true;

        Vector2 jumpDir = (jumpTarget - (Vector2)transform.position).normalized;
        rb.velocity = jumpDir * attackSpeed;

        yield return new WaitForSeconds(1f);

        rb.velocity = Vector2.zero;
        moveSpeed = 5f;
        isAttacking = false;
    }

    void ChasePlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerPos.position, moveSpeed * Time.deltaTime);
    }
    void backToSpawn()
    {
        transform.position = Vector2.MoveTowards(transform.position, startPos, moveSpeed * Time.deltaTime);
    }

    public void noticePlayerCombatStatus(bool _isInCombat)
    {
        player.GetComponent<Player_Status>().updateCombatStatus(_isInCombat);
    }
   
    public void resetStartPosition(Vector2 newStartPos) { startPos.y = newStartPos.y; startPos.x = newStartPos.x;}
    public Vector2 getStartPosition() { return startPos; }
}
