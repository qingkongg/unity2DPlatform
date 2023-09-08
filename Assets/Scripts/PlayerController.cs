using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D playerRigibody;
    private Animator playerAnimator;
    private BoxCollider2D playerFeet;

    public float MoveSpeed = 1.0f;
    public float JumpSpeed = 1.0f;

    private bool isRun = false;
    private bool isGround = false;
    // Start is called before the first frame update
    void Start()
    {
        playerRigibody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerFeet = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckGround();
        Run();
        Flip();
        Jump();
        SwitchAnimation();
    }

    void Flip()
    {
        if (isRun)
        {
            if(playerRigibody.velocity.x > 0.1f)
            {
                transform.localRotation = Quaternion.Euler(0 ,0 ,0);
            }
            else if (playerRigibody.velocity.x < -0.1f)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }

    private void Run()
    {
        float moveDirection = Input.GetAxis("Horizontal");
        isRun  = Mathf.Abs(moveDirection) > Mathf.Epsilon ;// 一个大于零的最小浮点数
        Vector2 Move = new Vector2(moveDirection * MoveSpeed ,playerRigibody.velocity.y);
        playerRigibody.velocity = Move;
        playerAnimator.SetBool("IsRun",isRun);

    }

    private void CheckGround()
    {
        isGround =  playerFeet.IsTouchingLayers(LayerMask.GetMask("Ground"));
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (isGround)
            {
                Vector2 jumpVector = new Vector2(0.0f, JumpSpeed);
                playerRigibody.velocity = Vector2.up * jumpVector;
                playerAnimator.SetBool("Jump",true);
            }
        }       
    }

    private void SwitchAnimation()
    {
        playerAnimator.SetBool("Idle",false);
        if (playerAnimator.GetBool("Jump"))
        {
            if(playerRigibody.velocity.y < 0.0f)
            {
                playerAnimator.SetBool("Jump", false);
                playerAnimator.SetBool("Fall", true);
            }
        }
        else if(isGround)
        {
            playerAnimator.SetBool("Idle",true);
            playerAnimator.SetBool("Fall", false);
        }
    }
}
