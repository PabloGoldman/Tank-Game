using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] float speed;

    Rigidbody rb;

    float lifetime = 2;

    private void Awake()
    {
        rb = GetComponentInChildren<Rigidbody>();

        Destroy(gameObject, lifetime);
    }

    void FixedUpdate()
    {
        rb.AddForce(transform.forward * speed, ForceMode.Impulse);
    }
}
