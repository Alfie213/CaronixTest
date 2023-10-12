using TMPro;
using UnityEngine;

public class PlayerInfoInitializer : MonoBehaviour
{
    [Header("TextMeshProUGUI")]
    [SerializeField] private TextMeshProUGUI playerName;
    [SerializeField] private TextMeshProUGUI playerMoney;

    [Header("PlayerData")] [SerializeField]
    private PlayerData playerData;

    private void Awake()
    {
        playerName.text = playerData.playerName;
        playerMoney.text = playerData.playerMoney.ToString();
    }
}
