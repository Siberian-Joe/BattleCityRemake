using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public event Action DestroyEvent;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.GetComponent<Shell>() != null)
        {
            DestroyEvent?.Invoke();
            Destroy(this);
        }
    }
}
