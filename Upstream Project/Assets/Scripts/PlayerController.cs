using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Rigidbody2D rb2D;
    private const float rateOfDescentForFish = -1.0f;
    private const float movementSpeedHorizontallyForFish = 1.0f;
    private Vector2 fishVelocity = new Vector2(movementSpeedHorizontallyForFish, rateOfDescentForFish);
    public BubbleEmitter bubbleEmitter;

    // Use this for initialization
    void Start () {
        rb2D = GetComponent<Rigidbody2D>();
        createNewBubbleEmitter();
    }

	// Update is called once per frame
	void Update () {
        rb2D.MovePosition(rb2D.position + (fishVelocity * Time.fixedDeltaTime));

        if (Time.fixedTime % 4.0f == 0.0f) {
            createNewBubbleEmitter();
        }
    }

    void changeFishSwimDirection() {
        fishVelocity.x = fishVelocity.x * (-1);
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        changeFishSwimDirection();
    }

    void createNewBubbleEmitter() {

        float targetPositionX = Random.Range(-4.0f, 4.0f);
        float targetPositionY = Random.Range(-6.0f, 6.0f);

        GameObject newBubbleEmitter = (GameObject)Instantiate(Resources.Load("bubbleEmitter"));
        newBubbleEmitter.transform.position = new Vector3(targetPositionX, targetPositionY, 0.0f);
    }
}
