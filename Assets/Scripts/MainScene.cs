using UnityEngine;
using System.Collections;

public class MainScene : MonoBehaviour {

    public GameObject enemyPrefab;
    public int numberOfEnemies = 3;

    float yBoundryTop = 4.0f;
    float yBoundryBottom = -4.0f;
    
    // an array that contains names of all enemies created
    string[] currentEnemyNames;
    int enemyBulletSpeed = 1;
    

    // Use this for initialization
    void Start ()
    {
        // create three enemies
        createEnemies(numberOfEnemies);        
	}

	// Update is called once per frame
	void Update ()
    {
        // check if all three enemies are dead and if so create
        // three new enemies
        GameObject player = GameObject.Find("Player");
        if (player != null)
        {
            bool allEnemiesDead = true;
            foreach (string name in currentEnemyNames)
            {
                // check if the enemy with the name exists
                if (GameObject.Find(name) != null)
                {
                    allEnemiesDead = false;
                    break;
                }
            }
            // if all enemies are dead , meaning that GameObject.Find
            // did not find any of the enemies then we should create N new
            // enemries
            if (allEnemiesDead)
            {
                createEnemies(numberOfEnemies);
            }
        }
	}

    // function to create numberOFEnemies of enemies by using Prefab
    void createEnemies(int numberOFEnemies)
    {
        currentEnemyNames = new string[numberOfEnemies];
        // there are numberOFEnemies objects we want to fit between
        // yBoundryTop and yBoundryBottom
        // so we use for loop here to create all objects and for each
        // enemy we need to specify their top posiiton, bottom position
        // and they speed they will move back and forth in the Y axis
        float zonePerEnemy = (yBoundryTop - yBoundryBottom) / numberOFEnemies;
        for (int i = 0; i < numberOFEnemies; i++)
        {
            float enemyBottomPosition = yBoundryBottom + i * zonePerEnemy;
            float enemyTopPosition = enemyBottomPosition + zonePerEnemy;
            GameObject clone = Instantiate(enemyPrefab, 
                new Vector3(0, (enemyBottomPosition+ enemyTopPosition)/2, 0),
                Quaternion.identity) as GameObject;
            string enemyName = string.Format("enemy-{0}", i);
            currentEnemyNames[i] = enemyName;
            clone.name = enemyName;
            EnemyMove em = clone.GetComponent<EnemyMove>();
            em.yBoundryBottom = enemyBottomPosition;
            em.yBoundryTop = enemyTopPosition;
            EnemyWeapon ew = clone.GetComponent<EnemyWeapon>();
            ew.bulletSpeed = enemyBulletSpeed;
        }
        //increase enemyBulletSpeed each time they are re-created
        enemyBulletSpeed++;
    }
}
