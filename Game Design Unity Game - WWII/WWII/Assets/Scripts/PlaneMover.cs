using UnityEngine;
using System.Collections;

public class PlaneMover : MonoBehaviour
{
	public float speed;
    public Rigidbody rb;

    void Start ()
	{
        float moveVertical = Input.GetAxis("Vertical");

        // GetComponent<Rigidbody>().velocity = Vector3.up * Input.GetAxis("Vertical") * Time.deltaTime); //transform.forward * speed;

        


    }
    private void FixedUpdate()
    {

    }
    void Update()
    {
        transform.position += new Vector3(0, 0, speed);
        /*
        float moveVertical = Input.GetAxis("Vertical");

        // GetComponent<Rigidbody>().velocity = Vector3.up * Input.GetAxis("Vertical") * Time.deltaTime); //transform.forward * speed;


        Vector3 movement = new Vector3(0.0f, 0.0f, moveVertical);
        Debug.Log(moveVertical);
        rb.velocity = movement * speed;*/

    }

}
