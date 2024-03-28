using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float enemyHp = 100;   
    private PlayerProgress progress;
    

    private void Start()
    {
        progress = FindObjectOfType<PlayerProgress>();
    }
    public void DealDamage(float damage)
    {
        progress.AddExpirience(damage);
        enemyHp -= damage;
        if (enemyHp <= 0)
        {

            Destroy(gameObject);

            
        }
    }
    public bool IsEnemyAlive()
    {
        if(enemyHp <= 0)
        {
            return false;
        }
        else return true;
    }
    

}
