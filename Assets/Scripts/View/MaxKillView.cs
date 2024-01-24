using Manager;
using Systems;
using TMPro;
using UnityEngine;

public class MaxKillView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _killText;

    private GameManager _gameManager;

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }
        
    public void Update()
    {
        _killText.text = "MAX KILLS: " + _gameManager.GetMaxKill();
    }
}
