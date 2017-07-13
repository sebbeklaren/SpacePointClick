using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour {

    private bool walking;
    public bool doorClick;
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
        DontDestroyOnLoad(gameObject);
        controller = GetComponent<CharacterController>();
        isMoving = false;        
    }
	
	
	void Update ()
    {        
        //här det var fel, karaktären fortsatte gå om man klickade högt eller lågt i y-led
        if (Vector3.Distance(currentPos, new Vector3(hit.point.x, -3.06f, 3.36f)) <= 4.0f)
        {
            isMoving = false;
        }
        lastPos = currentPos;
        Movement();      
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
                }
                if(hit.collider.CompareTag("DoorOut") && Vector2.Distance(GameObject.FindGameObjectWithTag("DoorOut").transform.position, gameObject.transform.position) < 4)
                {
                    targetedDoor = hit.transform;
                    doorClick = true;                    
                    isMoving = false;
                    gameObject.transform.position = new Vector3(-11f, currentPos.y, 3.2f);
                   
                }
                else if(!hit.collider.CompareTag("DoorOut") && !hit.collider.CompareTag("Mountain"))                {
                    doorClick = false;
                    mountainClicked = false;
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
        currentVelocityMod = Vector3.MoveTowards(transform.position, hit.point, 2 * Time.deltaTime);
       
        if (hit.point.x != currentVelocityMod.x && isMoving)
        {
            transform.position = new Vector3(currentVelocityMod.x, -3f, 3.2f);            
        }        
        currentPos = transform.position;
    }
}
