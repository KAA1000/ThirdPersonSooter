using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float maxSize = 5;
    public float damage = 50;
    public float speed = 1;
    void Start()
    {
        transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale += Vector3.one * Time.deltaTime * speed;
        if(transform.localScale.x > maxSize)
        {
            Destroy(gameObject);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        var playerHp = other.GetComponent<PlayerHealth>();
        if(playerHp != null)
        {
            playerHp.DealDamage(damage);
        }

        var enemyHp = other.GetComponent<EnemyHealth>();
        if(enemyHp != null) 
        {
            enemyHp.DealDamage(damage);
        }
    }
}
