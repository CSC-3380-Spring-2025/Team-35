using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    public int facingDirection = 1;
    public int speed = 5;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
        
    }

    void FixedUpdate()
    {
     

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
    
        if (horizontal > 0 && vertical == 0)
        {               
            anim.SetBool("walkingRight", true);
            anim.SetBool("walkingLeft", false);
            anim.SetBool("walkingUp", false);
            anim.SetBool("walkingDown", false);
            anim.SetBool("isIdle", false);
        }
        else if (horizontal < 0 && vertical == 0)
        {               
            anim.SetBool("walkingLeft", true);
            anim.SetBool("walkingRight", false);
            anim.SetBool("walkingUp", false);
            anim.SetBool("walkingDown", false);
            anim.SetBool("isIdle", false);
            
        }
        else if (vertical > 0 )
        {
            anim.SetBool("walkingUp", true);
            anim.SetBool("walkingRight", false);
            anim.SetBool("walkingLeft", false);
            anim.SetBool("walkingDown", false);
            anim.SetBool("isIdle", false);
        }
        else if (vertical < 0)
        {
            anim.SetBool("walkingUp", false);
            anim.SetBool("walkingRight", false);
            anim.SetBool("walkingLeft", false);
            anim.SetBool("walkingDown", true);
            anim.SetBool("isIdle", false);

        }
        else
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("walkingUp", false);
            anim.SetBool("walkingRight", false);
            anim.SetBool("walkingLeft", false);
            anim.SetBool("walkingDown", false);
        }

        rb.linearVelocity = new Vector2(horizontal, vertical) * speed;

    }
}