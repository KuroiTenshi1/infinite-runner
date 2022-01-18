using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpIntensity = 3;
    public LayerMask groundMask;

    private Rigidbody2D _rb;
    private Animator _animator;
    private GameObject _detectGround;
    private int _NbJump = 2;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _detectGround = transform.Find("DetectGround").gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!_animator.GetBool("GameStart"))
        {
            if (Input.GetButtonDown("Jump"))
                _animator.SetBool("GameStart", true);
        }
        else
        {
            Vector2 detectPosition =
                new Vector2(_detectGround.transform.position.x, _detectGround.transform.position.y);
            if (Physics2D.OverlapCircle(detectPosition, 0.01f, groundMask))
            {
                _NbJump = 2;
                _animator.SetBool("IsJumping", false);
            }

            if (Input.GetButtonDown("Jump") && _NbJump > 0)
            {
                _rb.AddForce(Vector2.up * jumpIntensity, ForceMode2D.Impulse);
                _NbJump--;
                _animator.SetBool("IsJumping", true);
            }
        }
    }
}