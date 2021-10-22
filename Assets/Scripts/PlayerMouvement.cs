using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{

    public CharacterController2D controller;
    public float runSpeed = 40f;
    public Animator animator;
    public Rigidbody2D rb;
    public CapsuleCollider2D playerCollider;

    float horinzontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    public static PlayerMouvement instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("PlayerMouvement already exist on scene");
        }

        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        horinzontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horinzontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    private void FixedUpdate()
    {
        // Move our Player
        controller.Move(horinzontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
