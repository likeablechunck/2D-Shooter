using UnityEngine;
using System.Collections;

public class BulletTrigger : MonoBehaviour {

    public GameObject explosionPrefab;
    public AudioSource audioSource;


    // Use this for initialization
    void Start ()
    {
        if (GameObject.Find("ExplosionAudioSource") != null)
        {
            audioSource = GameObject.Find("ExplosionAudioSource").GetComponent<AudioSource>();
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        // if a player bullet has hit an enemy
        // or if enemy bullet has hit the player
        if (gameObject.tag == "PlayerBullet" && other.tag == "Enemy")
        {
            if (audioSource != null)
            {
                audioSource.Play();
            }
            // create explosion from Prefab
            GameObject clone = Instantiate(explosionPrefab,
                other.transform.position, explosionPrefab.transform.rotation) as GameObject;
            // for enemy explosion use color blue
            clone.GetComponent<SpriteRenderer>().color = Color.blue;
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
        else if (gameObject.tag == "EnemyBullet" &&  other.tag == "Player")
        {
            if (audioSource != null)
            {
                audioSource.Play();
            }
            // create explosion from Prefab
            Instantiate(explosionPrefab, other.transform.position, explosionPrefab.transform.rotation);
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }

}
