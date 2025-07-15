using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Status : MonoBehaviour
{
    [SerializeField] float health = 5, ArcanePower =100;
    float maxHealth = 5, MaxArcanePower = 100;
    bool isInCombat = false;
    Vector2 spawnPosition;

    private void OnEnable()
    {
        spawnPosition = transform.position;
    }

    private void Update()
    {
        if(!isInCombat) { resetStatus(); }
        if(health <= 0)
        {
            respawnPlayer();
        }
    }

    void enterCombat() { isInCombat = true; }
    void exitCombat(){ isInCombat = false; resetStatus(); }

    public void updateCombatStatus(bool _isInCombat) {
        if(_isInCombat) { enterCombat(); }
        else { exitCombat(); }
    }
    public void reduceAP(float _reduceNumber) { ArcanePower -= _reduceNumber; }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enermy") { takeDamage(collision.gameObject.GetComponent<SlimeStatus>().GetEnermyDamage()); }
    }
    void takeDamage(float _damage) { health -= _damage; }
    
    void resetStatus() { health = maxHealth; ArcanePower = MaxArcanePower; }
    void resetPosition() { transform.position = spawnPosition; }
    void respawnPlayer()
    {
        resetStatus();
        resetPosition();
    }
}
