using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private PlayerControl playerControl;
    private PlayerAnimator playerAnimator;
    [SerializeField]private LayerMask platformLayer;

    public float movementSpeed;
    public float jumpPower;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        playerControl = GetComponent<PlayerControl>();
        playerAnimator = GetComponent<PlayerAnimator>();
    }

    void Update()
    {
        // player movement control
        if(playerControl.moveRight && playerControl.crouch || playerControl.moveLeft && playerControl.crouch)
        {
            playerAnimator.MoveAnimator(false);
        }
        else if(playerControl.moveRight)
        {
            rigidbody2D.velocity = new Vector2(+movementSpeed,rigidbody2D.velocity.y);
            transform.rotation = Quaternion.Euler(0,0,0);
            playerAnimator.MoveAnimator(true);
        }
        else if(playerControl.moveLeft)
        {
            rigidbody2D.velocity = new Vector2(-movementSpeed,rigidbody2D.velocity.y);
            transform.rotation = Quaternion.Euler(0,180,0);
            playerAnimator.MoveAnimator(true);
        }
        else
        {
            playerAnimator.MoveAnimator(false);
        }

        //check if player is hit platform        
        RaycastHit2D isGround = Physics2D.Raycast(transform.position,Vector2.down,0.2f,platformLayer);
        if(isGround.collider != null)
        {
            if(playerControl.jump) // player jump control
            {
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, +jumpPower);
                playerAnimator.JumpAnimator(true);
            }
            else
            {
                playerAnimator.JumpAnimator(false);
            }

            if(playerControl.crouch) // player crouch control
            {
                rigidbody2D.velocity = new Vector2(0,0);
                playerAnimator.CrouchAnimator(true);
            }
            else
            {
                playerAnimator.CrouchAnimator(false);
            }

            if(isGround.collider.gameObject.CompareTag("Dead Line"))
            {
                rigidbody2D.velocity = new Vector2(0,0);
                StartCoroutine(PlayerDead());
            }
            else
            {
                StopCoroutine(PlayerDead());
                playerAnimator.DeadAnimator(false);
            }
        }
    }

    IEnumerator PlayerDead()
    {
        playerAnimator.DeadAnimator(true);
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
        StopCoroutine(PlayerDead());
    }
}
