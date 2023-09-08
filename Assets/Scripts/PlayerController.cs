using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed = 1.0f;
    private Rigidbody2D playerRigibody;
    // Start is called before the first frame update
    void Start()
    {
        playerRigibody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
    }

    private void Run()
    {
        float moveDirection = Input.GetAxis("Horizontal");
        Vector2 Move = new Vector2(moveDirection * MoveSpeed ,playerRigibody.velocity.y);
        playerRigibody.velocity = Move;
    }
}
