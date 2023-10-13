public class PlayerDataHandler
{
    private readonly PlayerData playerData;

    public PlayerDataHandler(PlayerData playerData)
    {
        this.playerData = playerData;
    }

    public void IncreaseMoney(int value)
    {
        playerData.playerMoney += value;
    }
}
