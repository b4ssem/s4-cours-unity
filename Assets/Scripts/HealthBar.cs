using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private IntVariable currentLifePoints;
    [SerializeField]
    private IntVariable maxLifePoints;

    [SerializeField]
    private Image image;

    [SerializeField]
    private Gradient gradient;
    
    [SerializeField]
    private VoidEventChannel onPlayerTakeDamage;

    void OnEnable()
    {
        onPlayerTakeDamage.OnEventRaised += UpdateBar;
    }

    void OnDisable()
    {
        onPlayerTakeDamage.OnEventRaised -= UpdateBar;
    }

    void UpdateBar()
    {
        SetHealth((float)currentLifePoints.CurrentValue/maxLifePoints.CurrentValue);
    }
    public void SetHealth(float healthNormalized)
    {
        image.fillAmount = healthNormalized;
        image.color = gradient.Evaluate(healthNormalized);
    }
}
