using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    
    private Rigidbody2D _playerRb;
    private Animator _animator;
    
    private Vector2 _move;
    private static readonly int Attack = Animator.StringToHash("Attack");
    private static readonly int IsRunning = Animator.StringToHash("IsRunning");

    void Start()
    {
        _playerRb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }
    void Update()
    {
        _move = new Vector2(Input.GetAxis("Horizontal"), 0);
        PlayerMovement();
        PlayerAttack();
        RightFacing();
        Jump();
    }

    private void PlayerAttack()
    {
        if(Input.GetKeyDown(KeyCode.S))
            _animator.SetTrigger(Attack);
    }

    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            _playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void PlayerMovement()
    {
        Vector2 moveVector = transform.TransformDirection(_move) * speed; //make freeze rotation
        _playerRb.velocity = new Vector2(moveVector.x, _playerRb.velocity.y);
        _animator.SetBool(IsRunning, _playerRb.velocity.x != 0);
    }
    private void RightFacing()
    { 
        if (Input.GetAxisRaw("Horizontal") > 0) 
            transform.localScale = new Vector3(1, 1, 1);
        else if (Input.GetAxisRaw("Horizontal") < 0)
            transform.localScale = new Vector3(-1, 1, 1);
    }
}