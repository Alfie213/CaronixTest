using UnityEngine;

public class PlayerDataHandler : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;

    public void SetName(string newName)
    {
        playerData.playerName = newName;
    }
}
