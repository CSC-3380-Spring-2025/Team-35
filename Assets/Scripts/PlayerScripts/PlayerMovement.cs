using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
 public Rigidbody2D rb;
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
    
        if (horizontal > 0 && transform.localScale.x < 0 || horizontal < 0 && transform.localScale.x > 0)
        {               
            flip();
        }
        rb.linearVelocity = new Vector2(horizontal, vertical) * speed;

       // anim.SetFloat("horizontal", Mathf.Abs(horizontal));
        //anim.SetFloat("vertical", Mathf.Abs(vertical));
    }

       void flip()
    {
        facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    

    
   // in case we wish to implement 8 directional movement and animations i could set checks in fixed update to swithc the animation based
   // on the input. or i could probably do it through the animator. in a simpler way. 

   // this code still deoesn't control the change of direction from up to down.

}