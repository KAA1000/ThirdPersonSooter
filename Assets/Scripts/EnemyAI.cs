﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public List<Transform> patrolPoints;
    private PlayerController Player;
    public float viewAngle;
    public float damage = 30;
    private PlayerHealth _playerHealth;
    public EnemyHealth enemyHealth;
    

    private NavMeshAgent _navMeshAgent;
    private bool _isPlayerNoticed;


    void Start()
    {
        InitComponentLinks();
    }




    void Update()
    {
        ChaseUpdate();
        NoticePlayerUpdate();
        AttackUpdate();
        PatrolUpdate();



    }




    private void PatrolUpdate()
    {
        if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance && !_isPlayerNoticed)
        {
            _navMeshAgent.destination = patrolPoints[Random.Range(0, patrolPoints.Count)].position;
        }

    }

    private void InitComponentLinks()
    {
        Player = FindObjectOfType<PlayerController>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _playerHealth = Player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
    }
    


    //Проевека на наличие игрока в поле зрения. Присваивает переменной значиние типа boolean
    private void NoticePlayerUpdate()
    {
        _isPlayerNoticed = false;
        var direction = Player.transform.position - transform.position;
        RaycastHit hit;

        if (Vector3.Angle(direction, transform.forward) < viewAngle)
        {
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                if (hit.collider.gameObject == Player.gameObject)
                {
                    _isPlayerNoticed = true;
                }
            }
        }


    }

    private void ChaseUpdate()
    {
        if (_isPlayerNoticed)
        {
            _navMeshAgent.destination = Player.transform.position;
        }
    }
    private void AttackUpdate()
    {   
        if(_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance && _isPlayerNoticed)
        {
            _playerHealth.DealDamage(damage * Time.deltaTime);
        }
    }

    public bool IsEnemyAlive()
    {
        return enemyHealth.IsEnemyAlive();
    }
}


