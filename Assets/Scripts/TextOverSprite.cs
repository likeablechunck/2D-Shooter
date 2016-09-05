using UnityEngine;
using System.Collections;

public class TextOverSprite : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<MeshRenderer>().sortingLayerName = "Default";
        gameObject.GetComponent<MeshRenderer>().sortingOrder = 0;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
