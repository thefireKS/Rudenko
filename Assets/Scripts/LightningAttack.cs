using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;

public class LightningAttack : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    
    [Header("References")]
    [SerializeField] private GameObject lightning;

    [Header("Parameters")]
    [SerializeField] private float width;
    [SerializeField] private float height;
    
    private readonly List<GameObject> _enemiesArray = new List<GameObject>();

    private void Awake()
    {
        ContactFilter2D contactFilter2D = new ContactFilter2D().NoFilter();
        List<Collider2D> listCollider = new List<Collider2D>();
        BoxCollider2D rangeCollider = gameObject.AddComponent<BoxCollider2D>();
        rangeCollider.isTrigger = true;
        rangeCollider.size = new Vector2(width, height);
        rangeCollider.OverlapCollider(contactFilter2D, listCollider);
        foreach (var colliderInList in listCollider.Where(colliderInList => colliderInList.CompareTag("Enemy")))
        {
            _enemiesArray.Add(colliderInList.gameObject);
        }
        foreach (GameObject enemy in _enemiesArray)
        {
            Instantiate(lightning, enemy.transform.position, quaternion.identity);
            enemy.GetComponent<EnemyCore>().TakeDamage(damage);
        }
            
        Destroy(gameObject);
    }
}
