using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour {

    private bool walking;
    private bool doorClick;
    private bool mountainClicked;

    public  Vector2 currentPos, lastPos;
    private Vector2 currentVelocityMod;
    private Vector3 currentTargetX;
    private float stopDistance;
    private Transform targetedMountain;
    private Transform targetedDoor;
    //public Transform robotTarget;

    private CharacterController controller;
    private Camera camera;

    private Ray shootRay;
    RaycastHit hit;

    public bool isMoving;
    public bool flipCharacter;
   

    void Start ()
    {
        controller = GetComponent<CharacterController>();
        isMoving = false;        
    }
	
	// Update is called once per frame
	void Update ()
    {
        //robotTargetPos =  robotTarget.position;

        if (Vector2.Distance(currentPos, hit.point) <= 2)
        {
            isMoving = false;
        }
        lastPos = currentPos;
        Movement();
        //Debug.Log(isMoving);
    }  

    void Movement()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetButtonDown("Fire2"))
        {           
            isMoving = true;
            if(Physics.Raycast(ray, out hit, 100))
            {
                if(hit.collider.CompareTag("Mountain"))
                {
                    targetedMountain = hit.transform;
                    mountainClicked = true;
                   // Debug.Log("Träff");
                }
                if(hit.collider.CompareTag("DoorOut"))
                {
                    targetedDoor = hit.transform;
                    doorClick = true;
                   // Debug.Log("Träff door");                    
                }
                else if(!hit.collider.CompareTag("DoorOut") && !hit.collider.CompareTag("Mountain"))
                {
                    doorClick = false;
                    mountainClicked = false;                    
                   // Debug.Log("Ingen träff");
                }
                if(Vector2.Distance(GameObject.FindGameObjectWithTag("DoorOut").transform.position, transform.position) <= 4 && hit.collider.CompareTag("DoorOut"))
                {
                    //Debug.Log("Gå ut");
                }
            }
            if (hit.point.x >= transform.position.x)
            {
                flipCharacter = false;
                currentTargetX = new Vector3(hit.point.x, -2.25f, 3.34f);
            }
            else if (hit.point.x <= transform.position.x)
            {
                flipCharacter = true;
               currentTargetX = new Vector3(hit.point.x, -2.25f, 3.34f);
            }           
        }
        //Debug.Log(currentTargetX + " position: " + transform.position);
        currentVelocityMod = Vector3.MoveTowards(transform.position, currentTargetX, 2 * Time.deltaTime);  

        if (hit.point.x != transform.position.x && isMoving)
        {
            transform.position = new Vector3(currentVelocityMod.x, -3f, 3.2f);            
        }
        currentPos = transform.position;
    }
}
