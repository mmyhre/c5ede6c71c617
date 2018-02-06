using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public float fireRate = 0;
    public float Damage = 10;
    public LayerMask notToHit;

    // lager en public variabel slik at koden vet hva den skal bruke
    public Transform BallPrefab;
    public float speed = 5.0f;

    float timeToFire = 0;
    Transform firePoint;

	// Use this for initialization
	void Awake () {
        firePoint = transform.Find("Firepoint");
        if (firePoint == null) {
            Debug.LogError("No firepoint?");
        }

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (fireRate == 0){
            if (Input.GetButtonDown ("Fire1")){
                Shoot();
            }
        }
        else {
            if (Input.GetButton ("Fire1") && Time.time > timeToFire) {
                timeToFire = Time.time + 1 / fireRate;
                Shoot();
            }
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.parent.Rotate(Vector3.forward * Time.deltaTime * 100);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.parent.Rotate(Vector3.back * Time.deltaTime * 100);

        }
    }
    void Shoot(){

        var ball = Instantiate(BallPrefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);

        ball.GetComponent<Rigidbody2D>().velocity = transform.parent.up * speed;
        
    }
}
