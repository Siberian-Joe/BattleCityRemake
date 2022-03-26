using UnityEngine;

public class Tank : MonoBehaviour
{
    [SerializeField] private int _health = 1;

    public void OnDestroyed(Tank sender)
    {
        if (sender == this
            || sender.GetComponent<Enemy>() != null
            && GetComponent<Enemy>() != null)
            return;

        _health--;

        if (_health != 0)
            return;

        if (GetComponent<Player>() != null)
            EventManager.OnPlayerKilled(this);
        else if (GetComponent<Enemy>() != null)
            EventManager.OnEnemyKilled(this);

        Destroy(gameObject);
    }
}
