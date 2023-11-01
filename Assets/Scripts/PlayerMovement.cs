using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    private new Rigidbody rigidbody;
    [SerializeField] private float _rotationSpeed;

    [SerializeField] private float _speed;

    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    private bool inMovement;

    public bool InMovement
    {
        get { return inMovement; }
        set { inMovement = value; }
    }



    private Vector3 direction;

    private void Start()
    {
        inMovement = true;
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        PlayerMove();   
    }

    private void FixedUpdate()
    {
        PlayerFixedMove();
    }

    private void PlayerMove()
    {
        if (inMovement)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            direction = new Vector3(-vertical, 0, horizontal);
            if (direction.normalized != Vector3.zero)
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction), _rotationSpeed * Time.deltaTime);


            animator.SetFloat("speed", Vector3.ClampMagnitude(direction, 1f).magnitude);
        }
        else
        {
            animator.SetFloat("speed", 0);
        }
    }

    private void PlayerFixedMove()
    {
        rigidbody.velocity = Vector3.ClampMagnitude(direction, 1f) * _speed * Time.deltaTime;
        rigidbody.angularVelocity = Vector3.zero;
    }
    
}
