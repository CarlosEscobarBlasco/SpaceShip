using UnityEngine;
using System.Collections;

public class ObjectsMovement : MonoBehaviour
{
    private float rotationSpeed;
    private float fallSpeed;
    private bool paused;

	// Use this for initialization
	void Start ()
	{
	    paused = false;
	    rotationSpeed = Random.Range(-30, 30);
	    fallSpeed = Random.Range(0f, 0.025f);
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (!paused)
	    {
            rotateObject();
            moveDownObject();
	    }
    }

    private void moveDownObject()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - fallSpeed, gameObject.transform.position.z);
    }

    private void rotateObject()
    {
        gameObject.transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }

    void OnPauseGame()
    {
        paused = true;
    }

    void OnResumeGame()
    {
        paused = false;
    }
}
