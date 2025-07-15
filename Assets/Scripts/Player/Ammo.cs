using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 2f;
    float damage;
    private Vector2 direction;
    private void Start()
    {
        damage = Random.Range(3, 5);
    }

    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    public float GetDamage(){return damage;}
}
