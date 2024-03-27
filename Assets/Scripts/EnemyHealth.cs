using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float enemyHp = 100;   
    public PlayerProgress progress;

    
    public void DealDamage(float damage)
    {
        progress.AddExpirience(damage);
        enemyHp -= damage;
        if (enemyHp <= 0)
        {

            Destroy(gameObject);

            
        }
    }
    

}
