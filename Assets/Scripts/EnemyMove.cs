using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public Vector2 velocity;
    public float yBoundryTop = 2.0f;
    public float yBoundryBottom = -2.0f;
    public int speed = 1;
    private int direction;


    // Use this for initialization
    void Start()
    {
        // the starting point will be a point between bottom and top coordinate
        transform.position = new Vector3(5,
            Random.Range(yBoundryBottom, yBoundryTop), 0);
        direction = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // if player is dead we should not move the enemy anymore
        GameObject player = GameObject.Find("Player");
        if (player != null)
        {
            Vector3 currPosition = transform.position;
            if (direction == 1)
            {
                if (currPosition.y >= yBoundryTop)
                {
                    // it reached the top
                    //reverse enemy direction and move it south
                    direction = -1;
                }
            }
            else
            {
                if (currPosition.y <= yBoundryBottom)
                {
                    // it reached bottom
                    //reverse enemy direction and move it north
                    direction = 1;
                }
            }
            transform.Translate(new Vector3(0, direction * Time.deltaTime * speed, 0));
        }
    }
}
