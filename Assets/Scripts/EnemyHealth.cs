using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public float enemyHp = 100;
    private PlayerProgress progress;
    public Animator enemyAnimator;
    public AudioSource enemyDeathSound;
    

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
            OnEnemyDeath();
            //Destroy(gameObject);
            

            
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

    private void OnEnemyDeath()
    {
        GetComponent<EnemyAI>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;
        enemyAnimator.SetTrigger("death");
        enemyDeathSound.Play();
        Invoke("EnemyDestroyObject", 4);
    }

    private void EnemyDestroyObject()
    {
        Destroy(gameObject);
    }

}
