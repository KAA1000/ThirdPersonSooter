using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranadeCaster : MonoBehaviour
{
    public Rigidbody grenadePrefab;
    public Transform grenadeSourceTransform;
    public float force = 10;
    public float damage = 50;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            var granade = Instantiate(grenadePrefab);
            granade.transform.position = grenadeSourceTransform.position;
            granade.GetComponent<Rigidbody>().AddForce(grenadeSourceTransform.forward*force);
            granade.GetComponent<Grenade>().damage = damage;
        }
    }
}
