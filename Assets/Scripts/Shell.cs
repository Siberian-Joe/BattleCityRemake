using UnityEngine;

public class Shell : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject hitObject = collision.collider.gameObject;

        if (hitObject.GetComponent<Enemy>() != null || hitObject.GetComponent<Shell>() != null)
            Destroy(hitObject);

        Explosion();
        Destroy(gameObject);
    }

    private void Explosion()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _explosionRadius);

        foreach(Collider collider in colliders)
        {
            if(collider.GetComponent<Destroyable>() != false)
                Destroy(collider.gameObject);
        }
    }
}
