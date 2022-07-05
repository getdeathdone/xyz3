using UnityEngine;



public class Hero : MonoBehaviour
{   
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpSpeed;
    [SerializeField] private float _damageJumpSpeed;

    [SerializeField] private GameObject _objectToCount;   
    private int _countcoin;

    [SerializeField] private LayerCheck _groundCheck;
    private bool _isGrounded;
    private bool _allowDoubleJump;

    private Vector2 _direction;
    private SpriteRenderer _sprite;
    private Rigidbody2D _rigidbody;
    private Animator _animator;

    private static readonly int IsGroundKey = Animator.StringToHash("is-ground");
    private static readonly int IsRunning = Animator.StringToHash("is-running");
    private static readonly int VerticalVelocity = Animator.StringToHash("vertical-velocity");
    private static readonly int Hit = Animator.StringToHash("hit");

    private void Awake()
        {
            _sprite = GetComponent<SpriteRenderer>();
            _rigidbody = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
        }

    public void SetDirection(Vector2 direction)
        {
            _direction = direction;
        }

    public void Update()
    {
        _isGrounded = IsGrounded();
    }

    private void UpdateSpriteDirection()
        {
            if(_direction.x > 0)
            {
                _sprite.flipX = false;
            } else if (_direction.x < 0)
            {
                _sprite.flipX = true;
            }
        }

    private void FixedUpdate()
        {   
            var xVelocity = _direction.x * _speed;
            var yVelocity = CalculateYVelocity();
            _rigidbody.velocity = new Vector2(xVelocity, yVelocity);

            _animator.SetBool(IsGroundKey, _isGrounded);
            _animator.SetBool(IsRunning, _direction.x !=0);
            _animator.SetFloat(VerticalVelocity, _rigidbody.velocity.y);

            UpdateSpriteDirection();
 
        }

    private float CalculateYVelocity()
        {   
            var yVelocity = _rigidbody.velocity.y;
            var isJumpPress = _direction.y > 0;
            
            if(_isGrounded) _allowDoubleJump = true;

            if (isJumpPress)
            {   
                yVelocity = CalculateJumpVelocity(yVelocity);

            } else if (_rigidbody.velocity.y > 0)
            {
                yVelocity *= 0.5f;
            }  

            return yVelocity;
        }

    private float CalculateJumpVelocity(float yVelocity)
    {
        var isFalling = _rigidbody.velocity.y <= 0.001f;

        if(!isFalling) return yVelocity;
        
        if (_isGrounded) 
        {
            yVelocity += _jumpSpeed;
        } else if (_allowDoubleJump)
        {
            yVelocity = _jumpSpeed;
            _allowDoubleJump = false;
        }

        return yVelocity;
    }

    private void OnDrawGizmos()
        {   
            Gizmos.color = IsGrounded() ? Color.green : Color.red;
            Gizmos.DrawSphere(transform.position, 0.3f);
        }

    private bool IsGrounded()
        {   
            return _groundCheck.IsTouchingLayers;
        }

    public void CountObject()
        {
            _countcoin += 1;
            Debug.Log(_countcoin);        
        }

    public void SaySomesthing()
        {
            Debug.Log("Somesthing!");
        }

    public void TakeDamage()
    {
        _animator.SetTrigger(Hit);
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x,_damageJumpSpeed);
    }
}
