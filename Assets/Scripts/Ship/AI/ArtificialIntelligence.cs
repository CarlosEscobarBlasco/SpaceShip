using UnityEngine;
using System.Collections;

public class ArtificialIntelligence : MonoBehaviour
{

    ShipMovement movement;
    bool rightMovement;
    private RaycastHit2D hitCenter;
    private RaycastHit2D hitLeft;
    private RaycastHit2D hitRight;
    private bool startMoving;
    private bool myDirection;

    // Use this for initialization
    void Start()
    {
        movement = GetComponent<ShipMovement>();
        startMoving = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        hitCenter = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + 1), Vector2.up, 3, 1);
        hitLeft = Physics2D.Raycast(new Vector2(transform.position.x - 0.6f, transform.position.y + 1), Vector2.up, 3, 1);
        hitRight = Physics2D.Raycast(new Vector2(transform.position.x + 0.6f, transform.position.y + 1), Vector2.up, 3, 1);
        if (centerCollision())
        {
            if (leftCollision() && !rightCollision())
            {
                betterSideToMove(startMoving || myDirection);
                movement.move(myDirection);
            }
            else if (!leftCollision() && rightCollision())
            {
                betterSideToMove(!startMoving && myDirection);
                movement.move(myDirection);
            }
            else //solo el centro o los 3 a la vez
            {
                betterSideToMove(startMoving ? rightMovement : myDirection);
                movement.move(myDirection);
            }
        }
        else if (leftCollision())
        {
            betterSideToMove(startMoving || myDirection);
            movement.move(myDirection);
        }
        else if (rightCollision())
        {
            betterSideToMove(!startMoving && myDirection);
            movement.move(myDirection);
        }
        else
        {
            startMoving = true;
            rightMovement = goCenter();
            movement.noInput();
        }
        /*
        Debug.DrawLine(new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), new Vector3(transform.position.x, transform.position.y + 4, transform.position.z));
        Debug.DrawLine(new Vector3(transform.position.x-0.6f, transform.position.y + 1, transform.position.z), new Vector3(transform.position.x-0.6f, transform.position.y + 4, transform.position.z));
        Debug.DrawLine(new Vector3(transform.position.x+0.6f, transform.position.y + 1, transform.position.z), new Vector3(transform.position.x+0.6f, transform.position.y + 4, transform.position.z));
        */
    }

    private void betterSideToMove(bool right)
    {
        myDirection = right;
        if (startMoving)
        {
            startMoving = false;
            if (right && transform.position.x > 2.3f) myDirection = false;
            if (!right && transform.position.x < -2.3f) myDirection = true;
        }
    }

    private bool centerCollision()
    {
        return hitCenter.collider != null && hitCenter.collider.tag == "Obstacle";
    }

    private bool leftCollision()
    {
        return hitLeft.collider != null && hitLeft.collider.tag == "Obstacle";
    }

    private bool rightCollision()
    {
        return hitRight.collider != null && hitRight.collider.tag == "Obstacle";
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