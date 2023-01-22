using UnityEngine;

public class LightningProjectile : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
    }
}
