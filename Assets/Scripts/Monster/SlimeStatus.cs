using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeStatus : MonoBehaviour
{
    SlimeMovement _slimemovement;
    [SerializeField] float health = 20;
    float maxHealth = 20;
    float slimeDamage = 1;
    bool isMiniSlime = false;

    public GameObject slimePrefab;
    private void Start()
    {
        _slimemovement = GetComponent<SlimeMovement>();
    }
    void Update()
    {
        if(health <= 0)
        {
            if(!isMiniSlime){ spawnMiniSlime();}
            _slimemovement.noticePlayerCombatStatus(false);
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

    public void spawnMiniSlime()
    {
        GameObject miniClone = Instantiate(slimePrefab, transform.position, Quaternion.identity);
        miniClone.transform.localScale = miniClone.transform.localScale * 0.5f;
        SlimeStatus _ministatus = miniClone.GetComponent<SlimeStatus>();
        _ministatus.setSlimeMaxHealth(5);
        _ministatus.setSlimeMini();
        miniClone.GetComponent<SlimeMovement>().resetStartPosition(this.gameObject.GetComponent<SlimeMovement>().getStartPosition());
    }
}
