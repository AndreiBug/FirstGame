using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    [SerializeField] private float speed = 5f;

    private Rigidbody2D rb;
    private float mx;
    private float my;

    private Vector2 mousePos;
    public Camera mainCam;

    public Animator anim;
    private bool moving;
    private Vector2 input;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        mx = Input.GetAxisRaw("Horizontal"); // A D
        my = Input.GetAxisRaw("Vertical"); // W S
        input = new Vector2(mx, my);
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Animate();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(mx, my).normalized * speed;
        Vector2 lookDir = mousePos - rb.position;
        if (lookDir.x < 0) //if the X component of lookDir is negative, you are looking to the left
        {
            transform.localScale = new Vector3(-1, 1, 1);//Flip the image across the X axis
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    private void Animate()
    {
        if (input.magnitude < 0.1f || input.magnitude < -0.1f)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }
        if (moving)
        {
            anim.SetFloat("x", mx);
            anim.SetFloat("y", my);
        }
        anim.SetBool("Moving", moving);
    }

}