using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class PlayerUI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameplayUI;
    public GameObject winUI;
    public GameObject startUI;
    public TextMeshProUGUI Timer;

    private bool _isGameplayUIActive = false;
    void Start()
    {
        gameplayUI.SetActive(_isGameplayUIActive);
    }

    // Update is called once per frame
    void Update()
    {
        WinUIUpdate();
        StartSceenUpdate();
        TimerUpdate();
    }

    private void TimerUpdate()
    {
        if (_isGameplayUIActive)
        {
            Timer.text = Math.Round(Time.timeSinceLevelLoad, 1).ToString();
        }
    }

    private void StartSceenUpdate()
    {
        if (!_isGameplayUIActive)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                startUI.SetActive(false);
                _isGameplayUIActive = true;
                gameplayUI.SetActive(_isGameplayUIActive);

            }
        }
    }
    private void WinUIUpdate()
    {
        if (_isGameplayUIActive && Time.timeSinceLevelLoad >= 170)
        {
            _isGameplayUIActive = false;
            gameplayUI.SetActive(_isGameplayUIActive);
            winUI.SetActive(true);
            GetComponent<PlayerController>().enabled = false;
            GetComponent<fireballCaster>().enabled = false;
            GetComponent<CameraRotation>().enabled = false;
            Destroy(GetComponent<PlayerHealth>().gameOverUI);
            FindObjectOfType<EnemySpawner>().enabled = false;
        }
    }
}
