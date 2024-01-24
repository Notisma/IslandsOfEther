using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprit : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            animator.SetInteger("Speed", 0);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            animator.SetInteger("Speed", 1);
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            animator.SetInteger("Speed", 0);
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            animator.SetInteger("Speed", 0);
        }
    }
}
