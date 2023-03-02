using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // components
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anim;

    // animation variables
    private bool facingRight;
    private bool animationPlaying = false;

    // movement variables
    [SerializeField] private float walkSpeed = 2.5f;
    [SerializeField] private float runSpeed = 5.0f;
    private float horizontalInput;
    private bool actionable = true;     // whether the player can input stuff

    // lighter stuff
    private UnityEngine.Rendering.Universal.Light2D lighter;
    private bool holdingLighter;

    void Start()
    {
        lighter = GetComponentInChildren<UnityEngine.Rendering.Universal.Light2D>();
    }

    void Update()
    {
        if(actionable && !animationPlaying)
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");

            if((!facingRight && horizontalInput < 0.0f) || (facingRight && horizontalInput > 0.0f))
                Flip();
        }
    }

    void FixedUpdate()
    {
        if(actionable){
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

            // updates animator variables
            anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
            anim.SetBool("HoldingLighter", holdingLighter);
        }
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

    public void freezePlayer()
    {
        actionable = false;
    }

    public void releasePlayer()
    {
        actionable = true;
    }
}
