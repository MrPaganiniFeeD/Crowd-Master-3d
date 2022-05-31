using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Box : MonoBehaviour, IDamagable
{
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public bool ApplyDamage(Rigidbody rigidbody, float force)
    {
        Vector3 direction = transform.position - rigidbody.position;
        direction.y = 0;
        _rigidbody.AddForce(direction * force * 3, ForceMode.Impulse);
        return true;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.TryGetComponent(out DamageHandler enemy))
        {
            enemy.ApplyDamage(_rigidbody, _rigidbody.velocity.magnitude);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out EnemyDamageHandler enemy))
        {
            enemy.ApplyDamage(_rigidbody, _rigidbody.velocity.magnitude);
            Debug.Log(enemy);
            Debug.Log(_rigidbody.velocity.magnitude);
        }
    }
}
