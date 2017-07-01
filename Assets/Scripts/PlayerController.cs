using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour {

    private bool walking;
    private bool mountainClicked;

    private Vector2 currentVelocityMod;
    private Transform targetedMountain;
    private CharacterController controller;
    private Camera camera;

    private Ray shootRay;
    RaycastHit hit;

    void Start ()
    {
        controller = GetComponent<CharacterController>();
       
    }
	
	// Update is called once per frame
	void Update ()
    {
        Controller();
        
    }

    void Controller()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        


        if (Input.GetButtonDown("Fire2"))
        {
            if(Physics.Raycast(ray, out hit, 100))
            {
                if(hit.collider.CompareTag("Mountain"))
                {
                    targetedMountain = hit.transform;
                    mountainClicked = true;
                    Debug.Log("Träff");
                }
                else
                {
                    walking = true;
                    mountainClicked = false;
                    
                    Debug.Log("Ingen träff");
                }
            }           
        }

        currentVelocityMod = Vector2.MoveTowards(transform.position, hit.point, 2 * Time.deltaTime);
        if (hit.point.x != transform.position.x)
        {
            transform.position = new Vector2(currentVelocityMod.x, -2f);
        }
        //Vector2 motion = currentVelocityMod;
        //motion += Vector2.up * -8;
        //controller.Move(motion * Time.deltaTime);

    }
}
