using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeStatus : MonoBehaviour
{
    [SerializeField] float health = 20;
    float slimeDamage = 1;
    void Start()
    {
        
    }

    void Update()
    {
        if(health <= 0)
        {

        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Ammo") {
           float _damage = col.gameObject.GetComponent<Ammo>().GetDamage();
            health -= _damage; 
            Destroy(col.gameObject);
        }
    }

    public float GetEnermyDamage()
    {
        return slimeDamage;
    }
}
