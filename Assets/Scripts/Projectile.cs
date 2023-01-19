using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float velocity;
    [SerializeField] private float destroyDistance = 10;
    
    void Update()
    {
        transform.position += transform.right * velocity * Time.fixedDeltaTime;
        if (Mathf.Abs(transform.position.x) > destroyDistance)
            Destroy(gameObject);
    }
}
