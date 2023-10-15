using TMPro;
using UnityEngine;

public class TMPMoneyInitializer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshProUGUI;
    [SerializeField] private PlayerData playerData;

    private void Awake()
    {
        textMeshProUGUI.text = playerData.lastMoneyReward.ToString();
    } 
}
