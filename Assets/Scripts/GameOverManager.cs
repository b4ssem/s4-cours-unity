using UnityEngine;
 
public class GameOverManager : MonoBehaviour
{
    [SerializeField]
    private VoidEventChannel OnPlayerDeath;
 
    [SerializeField]
    private GameObject gameoverMenu;
 
    void Awake()
    {
        gameoverMenu.SetActive(false);
    }
 
    void OnEnable()
    {
        OnPlayerDeath.OnEventRaised += DisplayScreen;
    }
 
    void DisplayScreen()
    {
        gameoverMenu.SetActive(true);
    }
 
    void OnDisable()
    {
        OnPlayerDeath.OnEventRaised -= DisplayScreen;
    }
}
 