using UnityEngine;
using System.Collections;

public class MovingBackground : MonoBehaviour
{

    public float speed;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        GameObject player = GameObject.Find("Player");
        if (player != null)
        {
            this.transform.Translate(speed * Time.deltaTime, 0, 0);

            // If past a certain point on X
            if (this.transform.position.x > 6)
            {
                // Jump far to the right
                // moving from 6 to -6: difference 12
                this.transform.Translate(-12f, 0, 0);
            }
        }
    }

}
