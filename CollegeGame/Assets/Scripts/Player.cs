using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // components
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anim;

    // player start point
    public Vector2 playerStartPos = new Vector2(-0.4f, 0.518f);

    // animation variables
    private bool facingRight;
    private bool animationPlaying = false; // this variable is used by the animator

    // movement variables
    [SerializeField] private float walkSpeed = 2.5f;
    [SerializeField] private float runSpeed = 5.0f;
    private float horizontalInput;
    public bool disableMovement = false;

    // lighter stuff
    private UnityEngine.Rendering.Universal.Light2D lighter;
    private bool holdingLighter;

    void Start()
    {
        lighter = GetComponentInChildren<UnityEngine.Rendering.Universal.Light2D>();
    }

    void Update()
    {
        if(!animationPlaying)
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");
        }
    }

    void FixedUpdate()
    {
        if(!disableMovement)
        {
            // which way the character faces
            if((!facingRight && horizontalInput < 0.0f) || (facingRight && horizontalInput > 0.0f))
                Flip();

            // running & walking
            if(Input.GetButton("Sprint"))
                rb.velocity = new Vector2(horizontalInput * runSpeed, rb.velocity.y);
            else
                rb.velocity = new Vector2(horizontalInput * walkSpeed, rb.velocity.y);

            // lighter controls
            if(Input.GetButton("Lighter") && !Input.GetButton("Sprint"))
                holdingLighter = true;
            else {
                holdingLighter = false;
                releaseLighter();
            }
        } else {
            horizontalInput = 0.0f;
            rb.velocity = new Vector2(0, 0);
        }

        // updates animator variables
        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        anim.SetBool("HoldingLighter", holdingLighter);
    }

    // animation functions
    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 ls = transform.localScale;
        ls.x *= -1.0f;
        transform.localScale = ls;
    }


    // Animation events
    public void setAnimationPlaying()
    {
        animationPlaying = true;
    }

    public void unsetAnimationPlaying()
    {
        animationPlaying = false;
    }

    public void flickLighter()
    {
        lighter.enabled = true;
    }

    public void releaseLighter()
    {
        lighter.enabled = false;
    }
}
