using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Status : MonoBehaviour
{
    [SerializeField] float health = 5, ArcanePower =100;
    float maxHealth = 5, MaxArcanePower = 100;
    bool isInCombat = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void enterCombat() { isInCombat = true; print("FIGHT"); }
    void exitCombat(){ isInCombat = false; health = maxHealth; ArcanePower = MaxArcanePower; print("ESCAPE"); }

    public void updateCombatStatus(bool _isInCombat) {
        if(_isInCombat) { enterCombat(); }
        else { exitCombat(); }
    }
}
