using UnityEngine;

public class Tank : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<Shell>() != null)
        {
            if (GetComponent<Player>() != null)
                EventManager.OnPlayerKilled(this);
            else if (GetComponent<Enemy>() != null)
                EventManager.OnEnemyKilled(this);

            Destroy(this);
        }
    }
}
