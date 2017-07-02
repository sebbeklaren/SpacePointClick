using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotAnimation : MonoBehaviour
{

    Animator anim;
    SpriteRenderer spriteRender;

    void Start()
    {
        anim = GetComponent<Animator>();
        spriteRender = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().isMoving)
        {
            anim.SetInteger("State", 1);

        }
        else if (!GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().isMoving)
        {

            anim.SetInteger("State", 0);
        }
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().flipCharacter)
        {
            spriteRender.flipX = true;
        }
        else if (!GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().flipCharacter)
        {
            spriteRender.flipX = false;
        }
    }
}
