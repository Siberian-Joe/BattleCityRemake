using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>() == null)
            return;

        OnPickUp();
        Destroy(gameObject);
    }

    protected abstract void OnPickUp();
}
