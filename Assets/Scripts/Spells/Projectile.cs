using UnityEngine;

namespace Spells
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float velocity;
        [SerializeField] private float destroyDistance = 10;
    
        void Update()
        {
            Transform projectileTransform = transform;
            projectileTransform.position += projectileTransform.right * (velocity * Time.fixedDeltaTime);
            if (Mathf.Abs(transform.position.x) > destroyDistance)
                Destroy(gameObject);
        }
    }
}
