using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public float damage = 10;
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * speed * Time.fixedDeltaTime);
        Invoke("DestroyFireball", lifeTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        DanageEnemy(collision);
        DestroyFireball();

    }

    private void DanageEnemy(Collision collision)
    {
        var enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.DealDamage(damage);
        }

    }

    private void DestroyFireball()
    {
        Destroy(gameObject);
    }



}