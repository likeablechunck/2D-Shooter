using UnityEngine;
using System.Collections;

public class BulletMove : MonoBehaviour {

    public int speed = 2;
    public int direction = 1;
    float xBoundryLeft = -5.64f;
    float xBoundryRight = 5.64f;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        GameObject player = GameObject.Find("Player");
        // if player is dead dont move bullets anymore
        if (player != null)
        {
            Vector3 currPosition = transform.position;
            // if bullet reached either side of the allowed X boundry
            // then destroy it
            if (currPosition.x > xBoundryLeft && currPosition.x <= xBoundryRight)
            {
                transform.Translate(new Vector3(direction * Time.deltaTime * speed, 0, 0));
            }
            else
            {
                DestroyObject(gameObject);
            }
        }
	}
}

