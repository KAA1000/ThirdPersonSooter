using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float enemyHp = 100;
    public void DealDamage(float damage)
    {
        enemyHp -= damage;
        if (enemyHp <= 0)
        {
            Destroy(gameObject);
        }
    }
    

}
