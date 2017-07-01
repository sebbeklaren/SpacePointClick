using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour {

    private float walkSpeed = 2f;
    public float runSpeed = 4;
    private CharacterController controller;
    private Camera camera;
    private Vector2 mousClickPos;
    private float speed = 2;
    private float distanceToClick;
    void Start ()
    {
        controller = GetComponent<CharacterController>();
        mousClickPos = transform.position;
    }
	
	// Update is called once per frame
	void Update ()
    {
        ControllWASD();
        distanceToClick = 0;
    }

    void ControllWASD()
    {
        camera = Camera.main;
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if(Input.GetKeyDown("w"))
        {
            input.y += 8;
        }
        else
        {
            input.y = 0;
        }
        
        if (Input.GetMouseButtonDown(0))
          {
             mousClickPos = camera.ScreenToWorldPoint(Input.mousePosition);
            //distanceToClick = Input.mousePosition.x;
            Debug.Log("this.x: " + transform.position.x + "mousepos: " + mousClickPos);
        }
        if (mousClickPos.x != transform.position.x)
        {
            transform.position = Vector2.MoveTowards(transform.position, mousClickPos, speed * Time.deltaTime);
        }
        else
        {
            
        }

       

        //transform.position = transform.position + input;
        //currentVolicityMod = Vector2.MoveTowards(currentVolicityMod, input, acceleration * Time.deltaTime);
        Vector2 motion = input;
       // motion *= (Mathf.Abs(input.x) == 1 && Mathf.Abs(input.y) == 1) ? 0.7f : 1;
        motion *= (Input.GetButton("Run")) ? runSpeed : walkSpeed;

        motion += Vector2.up * -1;
        controller.Move(motion * Time.deltaTime);
    }
}
