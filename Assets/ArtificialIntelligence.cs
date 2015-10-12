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
	void Update () {
        RaycastHit2D hitCenter = Physics2D.Raycast(new Vector2(transform.position.x,transform.position.y + 1), Vector2.up, 2);
        RaycastHit2D hitLeft = Physics2D.Raycast(new Vector2(transform.position.x - 0.6f, transform.position.y + 1), Vector2.up, 2);
        RaycastHit2D hitRight = Physics2D.Raycast(new Vector2(transform.position.x + 0.6f, transform.position.y + 1), Vector2.up, 2);
        if (hitLeft.collider != null)
        {
            if (hitLeft.collider.tag == "Obstacle") movement.lateralMovement(true);
        }else if (hitRight.collider != null)
        {
            if (hitRight.collider.tag == "Obstacle") movement.lateralMovement(false);
        }
        else if (hitCenter.collider != null)
        {
            if (hitCenter.collider.tag == "Obstacle") movement.lateralMovement(rightMovement);
        }
        else
        {
            rightMovement = goCenter();
            movement.noInput();
        }
        Debug.DrawLine(new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), new Vector3(transform.position.x, transform.position.y + 3, transform.position.z));
        Debug.DrawLine(new Vector3(transform.position.x-0.6f, transform.position.y + 1, transform.position.z), new Vector3(transform.position.x-0.6f, transform.position.y + 3, transform.position.z));
        Debug.DrawLine(new Vector3(transform.position.x+0.6f, transform.position.y + 1, transform.position.z), new Vector3(transform.position.x+0.6f, transform.position.y + 3, transform.position.z));
        
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
