using UnityEngine;

public class Eagle : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        GameObject hitObject = collision.collider.gameObject;

        if (hitObject.GetComponent<Shell>() != null)
        {
            EventManager.OnDefeat();
            Destroy(gameObject);
        }
    }
}
