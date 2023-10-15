using UnityEngine;

public class EntityDataHandler : MonoBehaviour
{
    [SerializeField] private EntityDataBase entityData;

    public void SetName(string newName)
    {
        entityData.entityName = newName;
    }
}
