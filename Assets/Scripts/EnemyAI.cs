using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public List<Transform> patrolPoints;
    public PlayerController Player;
    public float viewAngle;

    private NavMeshAgent _navMeshAgent;
    private bool _isPlayerNoticed;


    void Start()
    {
        InitComponentLinks();
    }




    void Update()
    {
        PatrolUpdate();
        NoticePlayerUpdate();
        ChaseUpdate();

    }




    private void PatrolUpdate()
    {
        if (_navMeshAgent.remainingDistance == 0 && !_isPlayerNoticed)
        {
            _navMeshAgent.destination = patrolPoints[Random.Range(0, patrolPoints.Count)].position;
        }
        
    }

    private void InitComponentLinks()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    //Проевека на наличие игрока в поле зрения. Присваивает переменной значиние типа boolean
    private void NoticePlayerUpdate()
    {
        _isPlayerNoticed = false;
        var direction = Player.transform.position - transform.position;
        RaycastHit hit;

        if (Vector3.Angle(direction,transform.forward) < viewAngle)
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
}
