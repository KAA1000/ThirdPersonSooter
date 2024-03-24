﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float playerHp = 100;
    public RectTransform valueRectTransform;

    private float _maxPLayerHp;

    public GameObject gameplayUI;
    public GameObject gameOverUI;
    private void Start()
    {
        _maxPLayerHp = playerHp;
    }
    public void DealDamage(float damage)
    {
        playerHp -= damage;
        if (playerHp <= 0)
        {
            PlayerIsDead();
        }
        DrawHealthBar();
    }
    private void PlayerIsDead()
    {
        gameplayUI.SetActive(false);
        gameOverUI.SetActive(true);
        GetComponent<PlayerController>().enabled = false;
        GetComponent<fireballCaster>().enabled = false;
        GetComponent<CameraRotation>().enabled = false;
    }
    private void DrawHealthBar()
    {
        valueRectTransform.anchorMax = new Vector2(playerHp / _maxPLayerHp, 1);
    }
}