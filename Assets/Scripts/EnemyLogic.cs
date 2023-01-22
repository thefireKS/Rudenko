using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    [HideInInspector] public bool isFacingLeft;

    [SerializeField] private float speed; 
    [SerializeField] private Transform castPos;

    private const float BaseCastDistance = 0.15f;

    private void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if(IsNearEdge()|| IsHittingWall())
            ChangeFacingDirection();

        _rb2d.velocity = new Vector2(Vector2.right.x * speed * transform.localScale.x, _rb2d.velocity.y);
    }

    private void ChangeFacingDirection()
    {
        transform.localScale = isFacingLeft ? new Vector3(1,1,1) : new Vector3(-1,1,1);
        isFacingLeft = !isFacingLeft;
    }

    private bool IsHittingWall()
    {
        var castPosition = castPos.position;

        Vector3 targetPos = castPosition;
        targetPos.x += BaseCastDistance * transform.localScale.x;

        Debug.DrawLine(castPosition, targetPos, Color.green);

        return Physics2D.Linecast(castPosition, targetPos, 1 << LayerMask.NameToLayer("Ground"));
    }


    private bool IsNearEdge()
    {
        var castPosition = castPos.position;
        
        Vector3 targetPos = castPosition;
        targetPos.y -= BaseCastDistance;

        Debug.DrawLine(castPosition, targetPos, Color.yellow);

        return !Physics2D.Linecast(castPosition, targetPos, 1 << LayerMask.NameToLayer("Ground"));
    }
}