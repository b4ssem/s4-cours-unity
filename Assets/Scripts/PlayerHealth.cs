using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private int currentLifePoints;
    [SerializeField]
    private int maxLifePoints;

    private bool isInvulnerable = false;

    [SerializeField]
    private TextMeshProUGUI currentLifePointsText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        currentLifePoints = maxLifePoints;
        currentLifePointsText.SetText(currentLifePoints.ToString());
    }

    public void TakeDamage(int damage = 1)
    {
        if (isInvulnerable)
        {
            return;
        }
        isInvulnerable = true;
        StartCoroutine(InvulnerableDuration());
        currentLifePoints = Mathf.Clamp(currentLifePoints-damage,0,maxLifePoints);
        currentLifePointsText.SetText(currentLifePoints.ToString());

        if (currentLifePoints == 0)
        {
            Debug.Log("Game over");
        }
    }

    IEnumerator InvulnerableDuration()
    {
        float duration = 5f;
        // float timeElapsed = 0f;

        yield return new WaitForSeconds(duration);
        Debug.Log("End");

        // while(timeElapsed < duration)
        // {
        //     timeElapsed += Time.deltaTime;

        //     yield return null;
        // }

        isInvulnerable = false;
    }
}
