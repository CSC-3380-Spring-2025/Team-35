using System;
using UnityEditor.Callbacks;
using UnityEngine;

public class NpcMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private int speed = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       rb = gameObject.GetComponent<Rigidbody2D>(); // get rigid body of game object with this script at the start
       anim = gameObject.GetComponent<Animator>();
        
    }



    public void RunDown() {
        Debug.Log("Executing RunDown Function Right now");
        rb = gameObject.GetComponent<Rigidbody2D>(); // get rigid body of game object with this script at the start
       anim = gameObject.GetComponent<Animator>();

        rb.linearVelocity = Vector2.down * speed; // i might be able to to set this up in the prefab view instead
        anim.SetBool("isRunningUp", false);
        anim.SetBool("isRunningDown", true);

    }


    public void RunUp() {
        Debug.Log("Executing RunUp Function Right now");
        rb = gameObject.GetComponent<Rigidbody2D>(); // get rigid body of game object with this script at the start
        anim = gameObject.GetComponent<Animator>();


        rb.linearVelocity = Vector2.up * speed;
        anim.SetBool("isRunningDown", false);
        anim.SetBool("isRunningUp", true);
        
    }
    
}

public enum State
{
    IdleRight,
    IdleLeft,
    IdleUp,
    IdleDown,

    RunningUp,
    RunningDown,
    RunningLeft,
    RunningRight,

}
