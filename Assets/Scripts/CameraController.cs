using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smooth= 5.0f;
    
    private readonly Vector3 _offset = new Vector3(0, 1, -5);
    private void  Update()
    {
        transform.position = Vector3.Lerp (transform.position, target.position + _offset, Time.deltaTime * smooth);
    }
}
