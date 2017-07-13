using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneAnimation : MonoBehaviour {

    Animator anim;
    SpriteRenderer spriteRender;

	void Start ()
    {
        anim = GetComponent<Animator>();
        spriteRender = GetComponent<SpriteRenderer>();
	}
	
	
	void Update ()
    {

		if(GameObject.FindGameObjectWithTag("Clone").GetComponent<CloneController>().isMoving)
        {
            anim.SetInteger("State", 2);
            //Debug.Log("State 2");
            
        }
        else if(!GameObject.FindGameObjectWithTag("Clone").GetComponent<CloneController>().isMoving)
        {
            
            anim.SetInteger("State", 1);
        }
        if (GameObject.FindGameObjectWithTag("Clone").GetComponent<CloneController>().flipCharacter)
        {
            spriteRender.flipX = true;
        }
        else if (!GameObject.FindGameObjectWithTag("Clone").GetComponent<CloneController>().flipCharacter)
        {
            spriteRender.flipX = false;
        }


    }
}
