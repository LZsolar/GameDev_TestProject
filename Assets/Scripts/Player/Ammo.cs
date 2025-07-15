using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10f;
    public float lifetime = 2f;

    private Vector2 direction;

    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
        Destroy(gameObject, lifetime); // Auto-destroy after some time
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
