using UnityEngine;
using System.Collections;

public class DestroyAfterSeconds : MonoBehaviour {

    public int lifetime = 1;

	// Use this for initialization
	void Start () {
        // it destroys the object after lifetime seconds
        Destroy(this.gameObject, lifetime);
    }

}
