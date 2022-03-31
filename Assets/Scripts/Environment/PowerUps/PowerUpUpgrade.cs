public class PowerUpUpgrade : PowerUp
{
    protected override void OnPickUp()
    {
        EventManager.OnPowerUpPickUp(PowerUps.Upgrade, 0);
    }
}
