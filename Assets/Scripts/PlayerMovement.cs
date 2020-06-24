using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speedOfPlayer = 2f;
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetAxis("Vertical") != 0)
        {
           
            transform.position = new Vector3(transform.position.x, transform.position.y +
                                            (Input.GetAxis("Vertical") * speedOfPlayer * Time.deltaTime),
                                             transform.position.z);
        }

        else if (Input.GetAxis("Horizontal") != 0)
        {

            transform.position = new Vector3(transform.position.x + (Input.GetAxis("Horizontal") * speedOfPlayer * Time.deltaTime), 
                                             transform.position.y, transform.position.z
                                            );

        }

    }
}
