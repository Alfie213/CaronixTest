using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EntityDataWriter : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private Button button;

    [Header("EntityData")] [SerializeField]
    private EntityDataBase entityData;

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
        entityData.entityName = inputField.text;
    }
}
