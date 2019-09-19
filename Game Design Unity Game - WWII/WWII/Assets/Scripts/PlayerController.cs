using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMax, zMin;
}

public class PlayerController : MonoBehaviour {
    //public GameObject gameObject;
    public Rigidbody rb;
	public float speed;
	public Boundary boundary;

    public GameObject missile;
    public Transform missileFire;
    public float fireRate;

    private float nextFire;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(missile, missileFire.position, missileFire.rotation);
            GetComponent<AudioSource>().Play();
        }
    }

    void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.velocity = movement * speed;
        
		rb.position = new Vector3 (
			Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax),
			0.0f,
			Mathf.Clamp (rb.position.z, boundary.zMin, boundary.zMax)

		);


    }
    /*
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Parachute Collider " + other.name);

        if (other.tag == "boundary")
        {
            return;
        }
       

        Destroy(other.gameObject);
        Destroy(gameObject);
    }
    */
}
