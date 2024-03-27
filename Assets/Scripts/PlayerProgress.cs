using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerProgress : MonoBehaviour
{
    public RectTransform expirienceVlueRectTransform;
    public TextMeshProUGUI levelValueTMP;

    public List<PlayerProgressLevel> levels;

    private int _levelValue= 0;

    private float _currectExpirienceValue = 0;
    private float _targetExpirienceValue = 100;

    private void Start()
    {
        SetLevel(_levelValue);
        DrawUI();
    }

    public void AddExpirience(float value)
    {
        _currectExpirienceValue += value;
        if (_currectExpirienceValue >= _targetExpirienceValue)
        {
            SetLevel(_levelValue += 1);
            _currectExpirienceValue = 0;

        }
        DrawUI();
    }

    public void SetLevel(int value)
    {
        _levelValue = value;
        var currectLevel = levels[value];
        _targetExpirienceValue = currectLevel.expirienseForNextLevel;
        GetComponent<fireballCaster>().damage = currectLevel.fireballDamage;

        var grenadeCaster = GetComponent<GranadeCaster>();
        grenadeCaster.damage = currectLevel.grenadeDamage;

        if (currectLevel.grenadeDamage <0)
        {
            grenadeCaster.enabled = false;
        }
        else
        {
            grenadeCaster.enabled = true;
        }
    }

    private void DrawUI()
    {
        expirienceVlueRectTransform.anchorMax = new Vector3(_currectExpirienceValue / _targetExpirienceValue, 1);
        levelValueTMP.text = _levelValue.ToString();
        
        
    }
}
