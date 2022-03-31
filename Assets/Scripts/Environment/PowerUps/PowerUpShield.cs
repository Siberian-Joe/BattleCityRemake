using UnityEngine;

public class PowerUpShield : PowerUp
{
    [SerializeField] private float _duration = 15;

    protected override void OnPickUp()
    {
        EventManager.OnPowerUpPickUp(PowerUps.Shield, _duration);
    }
}