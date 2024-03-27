using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireballCaster : MonoBehaviour
{
    public Fireball fireballPrefab;
    public Transform fireballSource;
    public float damage = 10;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var fireball = Instantiate(fireballPrefab, fireballSource.position, fireballSource.rotation);
            fireball.damage = damage;   
        }
    }
}
