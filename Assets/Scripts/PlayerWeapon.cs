using UnityEngine;
using System.Collections;

public class PlayerWeapon : MonoBehaviour {

    public GameObject bulletPrefab;
    public int bulletSpeed = 1;
    private int bulletsShot;

    public AudioClip clip1;
    public AudioClip clip2;
    public AudioSource audioSource;

    // Use this for initialization
    void Start () {
        bulletsShot = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // counter for how many bullets this enemy has shot so far
            // the counter is used when naming each bullet
            bulletsShot++;
            GameObject clone = Instantiate(bulletPrefab, transform.position, Quaternion.identity) as GameObject;
            clone.name = string.Format("player-bullet-{0}", bulletsShot);
            BulletMove bm = clone.GetComponent<BulletMove>();
            bm.direction = 1;
            // set the bullet speed
            bm.speed = bulletSpeed;
            // set the bullet tag which is used in the trigger script
            bm.tag = "PlayerBullet";
            // player bullets are blue
            clone.GetComponent<SpriteRenderer>().color = Color.blue;
            // play sound ( choose between two clips )
            int randomNumber = Random.Range(-1, 1);
            if (randomNumber >= 0)
            {
                audioSource.clip = clip1;
            }
            else
            {
                audioSource.clip = clip2;
            }
            audioSource.Play();
        }
    }
}
