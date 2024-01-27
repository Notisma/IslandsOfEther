using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprite : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void HandleKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            animator.SetInteger("SpeedDown", 0);
            animator.SetInteger("SpeedUp", 1);
            animator.SetInteger("SpeedRight", 0);
            animator.SetInteger("SpeedLeft", 0);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            animator.SetInteger("SpeedDown", 1);
            animator.SetInteger("SpeedUp", 0);
            animator.SetInteger("SpeedRight", 0);
            animator.SetInteger("SpeedLeft", 0);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            animator.SetInteger("SpeedDown", 0);
            animator.SetInteger("SpeedUp", 0);
            animator.SetInteger("SpeedRight", 0);
            animator.SetInteger("SpeedLeft", 1);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            animator.SetInteger("SpeedDown", 0);
            animator.SetInteger("SpeedUp", 0);
            animator.SetInteger("SpeedRight", 1);
            animator.SetInteger("SpeedLeft", 0);
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            animator.SetInteger("SpeedUp", 0);
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            animator.SetInteger("SpeedDown", 0);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            animator.SetInteger("SpeedLeft", 0);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            animator.SetInteger("SpeedRight", 0);
        }
    }
}
