using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

   [SerializeField] private float _moveSpeed;
   public Transform leftSide, rightSide;


    private bool moveRight;
    private Rigidbody2D _theRB;
    private SpriteRenderer _theSR;
    private Animator _anim;

    [SerializeField] private float _moveTime;
    [SerializeField] private float _moveCount, _waitCount;


    private void Start()
    {
        _theRB = GetComponent<Rigidbody2D>();
        _theSR = GetComponentInChildren<SpriteRenderer>();
        _anim = GetComponent<Animator>();

        leftSide.parent = null;
        rightSide.parent = null;
        moveRight = true;
        _moveCount = _moveTime;

    }

    private void Update()
    {
        FrogMovement();
    }

    private void FrogMovement()
    {
        if (_moveCount > 0)
        {
            _moveCount -= Time.deltaTime;


            if (moveRight)
            {
                _theRB.velocity = new Vector2(_moveSpeed, _theRB.velocity.y);
                _theSR.flipX = true;
                if (transform.position.x > rightSide.position.x)
                {
                    moveRight = false;
                }

            }
            else
            {
                _theSR.flipX = false;
                _theRB.velocity = new Vector2(-_moveSpeed, _theRB.velocity.y);

                if (transform.position.x < leftSide.position.x)
                {
                    moveRight = true;

                }



            }
            if (_moveCount <= 0)
            {
                _waitCount = Random.Range(1f, 2f);
            }
            _anim.SetBool("isMoving", true);

        }
        else if (_waitCount > 0)
        {
            _waitCount -= Time.deltaTime;
            _theRB.velocity = new Vector2(0f, _theRB.velocity.y);
            _anim.SetBool("isMoving", false);
            if (_waitCount <= 0)
            {
                _moveCount = Random.Range(2f, 3.5f);
            }


        }


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealthController ph = collision.gameObject.GetComponent<PlayerHealthController>();
            ph.DealDamage();
        }


    }
}
