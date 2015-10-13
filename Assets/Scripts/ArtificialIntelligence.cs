using UnityEngine;
using System.Collections;

public class ArtificialIntelligence : MonoBehaviour {

    ShipMovement movement;
    bool rightMovement;

	// Use this for initialization
	void Start () {
        movement = GetComponent<ShipMovement>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        RaycastHit2D hitCenter = Physics2D.Raycast(new Vector2(transform.position.x,transform.position.y + 1), Vector2.up, 3,1);
        RaycastHit2D hitLeft = Physics2D.Raycast(new Vector2(transform.position.x - 0.6f, transform.position.y + 1), Vector2.up, 3,1);
        RaycastHit2D hitRight = Physics2D.Raycast(new Vector2(transform.position.x + 0.6f, transform.position.y + 1), Vector2.up, 3,1);
	    if (hitCenter.collider != null && hitCenter.collider.tag == "Obstacle")
	    {
	        
	    }
        else if (hitLeft.collider != null && hitLeft.collider.tag == "Obstacle")
        {
            //Debug.Log(hitLeft.collider.name + " en la izq");
            movement.checkSideToMove(true);
        }else if (hitRight.collider != null && hitRight.collider.tag == "Obstacle")
        {
            //Debug.Log(hitLeft.collider.name + " en la der");
            movement.checkSideToMove(false);
        }


        else if (hitCenter.collider != null && hitCenter.collider.tag == "Obstacle")
        {
            //Debug.Log(hitLeft.collider.name + " en el centro");
            movement.checkSideToMove(rightMovement);
        }
        else
        {
            rightMovement = goCenter();
            movement.noInput();
        }
        /*
        Debug.DrawLine(new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), new Vector3(transform.position.x, transform.position.y + 4, transform.position.z));
        Debug.DrawLine(new Vector3(transform.position.x-0.6f, transform.position.y + 1, transform.position.z), new Vector3(transform.position.x-0.6f, transform.position.y + 4, transform.position.z));
        Debug.DrawLine(new Vector3(transform.position.x+0.6f, transform.position.y + 1, transform.position.z), new Vector3(transform.position.x+0.6f, transform.position.y + 4, transform.position.z));
        */
	}

    bool goCenter()
    {
        if (transform.position.x < 0)
        {
            return true;
        }
        else if (transform.position.x > 0)
        {
            return false;
        }
        else return true;
    }
}
