using UnityEngine;

public class Shell : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;

    private Tank _sender;

    public Tank Sender { get => _sender; set => _sender = value; }

    private void OnCollisionEnter(Collision collision)
    {
        Explosion();
        Destroy(gameObject);
    }

    private void Explosion()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _explosionRadius);

        foreach(Collider collider in colliders)
        {
            if(collider.TryGetComponent<Destroyable>(out Destroyable destroyableObject))
                destroyableObject.Destroy();
        }
    }
}
