using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeStatus : MonoBehaviour
{
    [SerializeField] float health = 20;
    float maxHealth = 20;
    float slimeDamage = 1;
    bool isMiniSlime = false;

    public GameObject slimePrefab;

    void Start()
    {
       
    }

    void Update()
    {
        if(health <= 0)
        {
            if(!isMiniSlime)
            {
                GameObject miniClone = Instantiate(slimePrefab, transform.position, Quaternion.identity);
                miniClone.transform.localScale = miniClone.transform.localScale * 0.5f;
                miniClone.GetComponent<SlimeStatus>().setSlimeMaxHealth(5);
                miniClone.GetComponent<SlimeStatus>().setSlimeMini();
            }
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
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

    public void setSlimeMaxHealth(float _hp) { maxHealth = _hp; health = maxHealth; }
    public void setSlimeMini() { isMiniSlime = true; }
}
