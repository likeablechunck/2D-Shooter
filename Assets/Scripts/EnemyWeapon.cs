using UnityEngine;
using System.Collections;

public class EnemyWeapon : MonoBehaviour {

    public GameObject bulletPrefab;
    private int bulletShots;
    private int shootRepeatInSecs = 3;
    public int bulletSpeed = 1;

	// Use this for initialization
	void Start () {
        // it starts calling launchBullet in between 1-4 seconds and
        // 3 seconds intervals after that
        bulletShots = 0;
        InvokeRepeating("launchBullet", 
            Random.Range(1,4),
            shootRepeatInSecs);
    }
	
	// Update is called once per frame
	void Update () {
	}

    void launchBullet()
    {
        GameObject player = GameObject.Find("Player");
        if (player != null)
        {
            // counter for how many bullets this enemy has shot so far
            // the counter is used when naming each bullet
            bulletShots++;
            GameObject clone = Instantiate(bulletPrefab, transform.position, Quaternion.identity) as GameObject;
            clone.name = string.Format("{0}-bullet-{1}", name, bulletShots);
            BulletMove bm = clone.GetComponent<BulletMove>();
            //enemy bullet direction is reverse
            bm.direction = -1;
            //set the bullet speed
            bm.speed = bulletSpeed;
            // set the tag which is used in the trigger script
            bm.tag = "EnemyBullet";
            //enemy bullets are red
            clone.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }
}
