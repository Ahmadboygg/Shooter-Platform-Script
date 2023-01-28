using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void MoveAnimator(bool value)
    {
        if(value)
        {
            animator.SetBool("isMove",true);
        }
        else
        {
            animator.SetBool("isMove",false);
        }
    }

    public void JumpAnimator(bool value)
    {
        if(value)
        {
            animator.SetBool("isJump",true);
        }
        else
        {
            animator.SetBool("isJump",false);
        }
    }

    public void CrouchAnimator(bool value)
    {
        if(value)
        {
            animator.SetBool("isCrouch",true);
        }
        else
        {
            animator.SetBool("isCrouch",false);
        }
    }

    public void DeadAnimator(bool value)
    {
        if(value)
        {
            animator.SetBool("isDead",true);
        }
        else
        {
            animator.SetBool("isDead",false);
        }
    }
}
