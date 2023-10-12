using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDataWriter : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private Button button;

    [Header("PlayerData")] [SerializeField]
    private PlayerData playerData;

    private void OnEnable()
    {
        button.onClick.AddListener(Handle_OnClick);
    }

    private void OnDisable()
    {
        button.onClick.RemoveListener(Handle_OnClick);
    }

    private void Handle_OnClick()
    {
        playerData.entityName = inputField.text;
    }
}
