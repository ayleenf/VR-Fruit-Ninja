using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour {

    //help moves the fruit upwards
    public float verticalForce = 500.0f;
    public float horizontalForce = 150f;
    public float lifetime = 2f;
	
    // Use start for initialization
	void Start () {
        Rigidbody rigidbody = GetComponent<Rigidbody> ();
        rigidbody.AddForce(new Vector3(
            Random.Range(-horizontalForce, +horizontalForce),
            verticalForce,
            0   
        ));
	}
	
	// Update is called once per frame
    //lifetime is what destroys fruit after 2 sec
	void Update () {
        lifetime -= Time.deltaTime;
        if (lifetime <= 0f) {
            Destroy(gameObject);
        }
	}
}
