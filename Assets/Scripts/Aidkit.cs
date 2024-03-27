using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aidkit : MonoBehaviour
{
    public float healthAmount;

    private void OnTriggerEnter(Collider other)
    {
        var playerHp = other.gameObject.GetComponent<PlayerHealth>();
        if (playerHp != null)
        {
            playerHp.AddHp(healthAmount);
            Destroy(gameObject);
        }
    }
}
