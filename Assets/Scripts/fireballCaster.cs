using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireballCaster : MonoBehaviour
{
    public Fireball fireballPrefab;
    public Transform fireballSource;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(fireballPrefab, fireballSource.position, fireballSource.rotation);
        }
    }
}
