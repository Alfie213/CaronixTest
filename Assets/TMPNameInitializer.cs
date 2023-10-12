using TMPro;
using UnityEngine;

public class TMPNameInitializer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshProUGUI;
    [SerializeField] private EntityDataBase entityData;
    
    private void Awake()
    {
        textMeshProUGUI.text = entityData.entityName;
    }
}
