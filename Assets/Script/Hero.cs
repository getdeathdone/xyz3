using UnityEngine;

public class Hero : MonoBehaviour
{   
    public int _heroSilverCoin;
    public int _heroGoldCoin;
    
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpSpeed;
    [SerializeField] private float _damageJumpSpeed;
    [SerializeField] private float _interactionRadius;
    
    [SerializeField] private LayerCheck _groundCheck;
    [SerializeField] private LayerMask _interackionLayer;
    
    private bool _isGrounded;
    private bool _allowDoubleJump;
    private Collider2D[] _interactionResult = new Collider2D[1];

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
    
    public void Update()
        {
            _isGrounded = IsGrounded();
        }
    
    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }
    private bool IsGrounded()
    {   
        return _groundCheck.IsTouchingLayers;
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
    
    private void UpdateSpriteDirection()
    {
        if (_direction.x > 0)
        {
            _sprite.flipX = false;
        } else if (_direction.x < 0) 
        {
            _sprite.flipX = true;
        }
    }

    public void TakeDamage()
    {
        _animator.SetTrigger(Hit);
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x,_damageJumpSpeed);
    }

    public void Interact()
    {
        var size = Physics2D.OverlapCircleNonAlloc(transform.position,_interactionRadius,_interactionResult,_interackionLayer);
        for (int i = 0; i < size; i++)
        {
            var interactable = _interactionResult[i].GetComponent<Interactable>();
            if (interactable != null)
                interactable.Interact();
        }
    }
}
