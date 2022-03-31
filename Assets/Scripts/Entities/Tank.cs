using UnityEngine;

public abstract class Tank : MonoBehaviour
{
    [SerializeField] private int _health = 1;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject != null && collision.gameObject.TryGetComponent(out Shell shell))
            OnHited(shell.Sender);
    }

    protected void GetHit()
    {
        _health--;

        if (_health == 0)
            OnKilled();
    }

    protected virtual void OnKilled()
    {
        Destroy(gameObject);
    }

    protected abstract void OnHited(Tank sender);
}
