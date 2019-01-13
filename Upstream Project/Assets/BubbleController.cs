using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleController : MonoBehaviour {

    private float bubbleDirect = 1.0f;
    private float moveX = 0.002f;
    private float moveY = 0.01f;

    // Use this for initialization
    void Start() {
        DestroyObjectDelayed();
    }

    // Update is called once per frame
    void Update() {
        if (Time.fixedTime % 1.0f == 0.0f) {
            bubbleDirect = bubbleDirect * (-1.0f);
            transform.position = new Vector3(transform.position.x + moveX, transform.position.y + moveY, 0.0f);
        }
        transform.position = new Vector3(transform.position.x + moveX * bubbleDirect, transform.position.y + moveY, 0.0f);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag != gameObject.tag) {
            Destroy(gameObject);
        }
    }

    void DestroyObjectDelayed() {
        Destroy(gameObject, 6.0f);
    }
}
