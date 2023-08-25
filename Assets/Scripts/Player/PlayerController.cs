using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [Header("Parameters")]
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask _layerIs;

    private Rigidbody2D _theRB;
    private Animator _anim;
    private SpriteRenderer _theSPR;
    private bool _isGrounded;
    private bool _doubleJump;



    [Header("References")]
    public GameObject groundCheckPoint;
    

    private void Start()
    {
        _theRB = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _theSPR = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {


        _theRB.velocity = new Vector2(_moveSpeed * Input.GetAxis("Horizontal"), _theRB.velocity.y);
        _isGrounded = Physics2D.OverlapCircle(groundCheckPoint.transform.position, 0.2f, _layerIs);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }


        if(_theRB.velocity.x < 0)
        {
            _theSPR.flipX = true;

        }
        else if(_theRB.velocity.x > 0)
        {
            _theSPR.flipX = false;
        }
        _anim.SetFloat("moveSpeed", Mathf.Abs(_theRB.velocity.x));
        _anim.SetBool("isGrounded", _isGrounded);

    }


    private void Jump()
    {
        
    
        if (_isGrounded)
        {

            _doubleJump = true;
        }

        if(_isGrounded)
        { 
            _theRB.velocity = new Vector2(_theRB.velocity.x, jumpForce); 
        
        }
        else
        {
            if (_doubleJump)
            {
                _theRB.velocity = new Vector2(_theRB.velocity.x, jumpForce);
                _doubleJump = false;

            }


        }
            
    }
}

