using System;
using System.Collections;
using NUnit.Framework;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private IntVariable currentLifePoints;
    [SerializeField]
    private IntVariable maxLifePoints;

    [SerializeField]
    private VoidEventChannel onTakeDamage;

    [SerializeField]
    private VoidEventChannel onPlayerDeath;

    private bool isInvulnerable = false;

    [SerializeField]
    private SpriteRenderer sr;

    [SerializeField]
    private TextMeshProUGUI currentLifePointsText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        currentLifePoints.CurrentValue = maxLifePoints.CurrentValue;
        currentLifePointsText.SetText(currentLifePoints.CurrentValue.ToString());
    }

    public void TakeDamage(int damage = 1)
    {
        if (isInvulnerable)
        {
            return;
        }
        isInvulnerable = true;
        StartCoroutine(InvulnerableDuration());
        currentLifePoints.CurrentValue = Mathf.Clamp(currentLifePoints.CurrentValue-damage,0,maxLifePoints.CurrentValue);
        currentLifePointsText.SetText(currentLifePoints.CurrentValue.ToString());
        onTakeDamage.Raise();
        if (currentLifePoints.CurrentValue == 0)
        {
            Debug.Log("Game over");
            onPlayerDeath.Raise();
        }
    }

    IEnumerator InvulnerableDuration()
    {
        isInvulnerable = true;
 
        float duration = 1.25f;
        float timeElasped = 0f;
 
        float flashDuration = 0.2f;
        float flashTimeElapsed = 0f;
 
        bool isVisible = true;
 
        while (timeElasped < duration)
        {
            timeElasped += Time.deltaTime;
            flashTimeElapsed += Time.deltaTime;
 
            if (flashTimeElapsed >= flashDuration)
            {
                if (isVisible)
                {
                    sr.color = Color.clear;
                } else
                {
                    sr.color = Color.white;
                }
 
                flashTimeElapsed = 0f;
                isVisible = !isVisible;
            }
 
            yield return null;
        }
 
        sr.color = Color.white;
        isInvulnerable = false;
    }
 
}
