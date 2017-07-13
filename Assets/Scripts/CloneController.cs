using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneController : MonoBehaviour {

    private bool walking;

    private Vector2 currentPos, lastPos;
    private Vector2 currentVeclocityMod;
    private Vector2 checkVel;
    private Vector2 targetPos;
    private float stopDistance;
    public bool isMoving;
    public bool flipCharacter;

    public Transform cloneTarget;

	void Start ()
    {
        DontDestroyOnLoad(gameObject);
        isMoving = false;
	}
	
	
	void Update ()
    {
       

        if (Vector2.Distance(cloneTarget.position, transform.position) <= 9 &&
            !GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().isMoving)
        {
            //Debug.Log("Nära: " + Vector2.Distance(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().robotTargetPos, transform.position));
            isMoving = false;
            if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().doorClick)
            {
                gameObject.transform.position = new Vector3(-11f, -1.8f, 3.2f);
               // Debug.Log("Out");
            }
        }

        if (currentPos == lastPos)
        {
            isMoving = false;
        }
        //checkVel = (targetPos - currentPos) / Time.deltaTime;       
        lastPos = currentPos;

        currentPos = transform.position;

        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().isMoving && Vector2.Distance(cloneTarget.position, transform.position) >= 2)
        {
            isMoving = true;
            targetPos = new Vector2(cloneTarget.position.x, 0);
        }
        currentVeclocityMod = Vector2.MoveTowards(transform.position, targetPos, 2.5f * Time.deltaTime);      

        if (targetPos.x >= transform.position.x)
        {
            flipCharacter = false;
        }
        else if (targetPos.x <= transform.position.x)
        {
            flipCharacter = true;
        }        
        
        if(targetPos.x != transform.position.x && isMoving)
        {
            transform.position = new Vector3(currentVeclocityMod.x, -1.8f, 3.4f);
        }
        currentPos = transform.position;
        
        //Debug.Log(isMoving);
    }
    
}
