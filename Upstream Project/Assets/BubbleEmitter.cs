using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleEmitter : MonoBehaviour {

    public Vector2 emitterSize = new  Vector2(1.0f, 1.0f);

    // Use this for initialization
    void Start () {
        createNewBubble();
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.fixedTime % 1.0f == 0.0f) {
            createNewBubble();
        }

        if (Time.fixedTime % 4.0f == 0.0f) {
            Destroy(gameObject);
        }
    }

    void createNewBubble() {

        float targetPositionX = transform.position.x + Random.Range(emitterSize.x, 0.0f);
        float targetPositionY = transform.position.y + Random.Range(emitterSize.y, 0.0f);
        float targetScale = Random.Range(0.1f, 1.0f);

        GameObject newBubble = (GameObject)Instantiate(Resources.Load("bubble"));
        newBubble.transform.position = new Vector3(targetPositionX, targetPositionY, 0.0f);
        newBubble.transform.localScale = new Vector3(targetScale, targetScale, targetScale);
    }
}
