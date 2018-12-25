using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Rigidbody2D rb2D;
    private const float rateOfDescentForFish = -2.0f;
    private const float movementSpeedHorizontallyForFish = 1.0f;
    private Vector2 fishVelocity = new Vector2(movementSpeedHorizontallyForFish, rateOfDescentForFish); 

    // Use this for initialization
    void Start () {
        rb2D = GetComponent<Rigidbody2D>();
    }

	// Update is called once per frame
	void Update () {
        rb2D.MovePosition(rb2D.position + (fishVelocity * Time.fixedDeltaTime));
    }

    void changeFishSwimDirection() {
        fishVelocity.x = fishVelocity.x * (-1);
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        changeFishSwimDirection();
    }
}
