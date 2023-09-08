using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D playerRigibody;
    private Animator playerAnimator;

    public float MoveSpeed = 1.0f;
    private bool isRun = false;
    // Start is called before the first frame update
    void Start()
    {
        playerRigibody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Run();
        Flip();
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
}
