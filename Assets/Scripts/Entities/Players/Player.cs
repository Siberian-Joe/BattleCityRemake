using UnityEngine;

[RequireComponent(typeof(IInput))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerShooting))]
[RequireComponent(typeof(PlayerPowerUpsEffects))]
public class Player : Tank
{
    [SerializeField] private Tank _upgradePlayerPefab;

    private IInput _input;
    private PlayerMovement _playerMovement;
    private PlayerShooting _playerShooting;
    private PlayerPowerUpsEffects _playerPowerUpsEffects;
    private bool _isShielded;

    private void Awake()
    {
        _input = GetComponent<IInput>();
        _playerMovement = GetComponent<PlayerMovement>();
        _playerShooting = GetComponent<PlayerShooting>();
        _playerPowerUpsEffects = GetComponent<PlayerPowerUpsEffects>();
    }

    private void OnEnable()
    {
        EventManager.PowerUpPickUp += OnPowerUpPickUp;
    }

    private void OnDisable()
    {
        EventManager.PowerUpPickUp -= OnPowerUpPickUp;
    }

    private void FixedUpdate()
    {
        _playerMovement.Move(_input.MovementInputVector);
        _playerShooting.SetShooting(_input.IsShooting);
    }

    public void ActivateShield()
    {
        _isShielded = true;
    }

    public void DeactivateShield()
    {
        _isShielded = false;
    }

    private void OnPowerUpPickUp(PowerUps powerUp, float duration)
    {
        _playerPowerUpsEffects.PowerUpDefinition(powerUp, duration, _upgradePlayerPefab);
    }

    protected override void OnHited(Tank sender)
    {
        if (sender == this || _isShielded == true)
            return;

        GetHit();
    }

    protected override void OnKilled()
    {
        EventManager.OnPlayerKilled();

        base.OnKilled();
    }
}