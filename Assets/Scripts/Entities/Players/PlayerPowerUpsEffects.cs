using System.Collections;
using UnityEngine;

public class PlayerPowerUpsEffects : MonoBehaviour
{
    public void PowerUpDefinition(PowerUps powerUp, float duration, Tank upgradePlayerPefab)
    {
        switch (powerUp)
        {
            case PowerUps.Shield:
                StartCoroutine(OnPickUpShield(duration));
                break;
            case PowerUps.Upgrade:
                OnPickUpUpgrade(upgradePlayerPefab);
                break;
            default:
                break;
        }
    }

    private IEnumerator OnPickUpShield(float duration)
    {
        Player player = gameObject.GetComponent<Player>();

        player.ActivateShield();

        yield return new WaitForSeconds(duration);

        player.DeactivateShield();
    }

    private void OnPickUpUpgrade(Tank upgradePlayerPefab)
    {
        Instantiate(upgradePlayerPefab, transform.position, transform.rotation);

        Destroy(gameObject);
    }
}