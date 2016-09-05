using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Vector2 velocity;
    public Rigidbody2D rb;
    float yBoundryTop = 4.0f;
    float yBoundryBottom = -4.0f;
    float xBoundryLeft = -5.64f;
    float xBoundryRight = 2;
    public int speed = 3;


    // Use this for initialization
    void Start ()
    {
        rb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        rb.transform.position = new Vector2(-4, yBoundryBottom + 0.01f);
    }
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 currPosition = transform.position;
        float hMove = Input.GetAxis("Horizontal");
        float vMove = Input.GetAxis("Vertical");
        float movePerSecond = Time.deltaTime * speed;
        //print(string.Format("hMove : {0} vMove: {1} position.x {2} position.y {3}",
        //    hMove, vMove, currPosition.x, currPosition.y));
        // hMove means user tried to use left or right arrow
        // vMove means user tried to use up or down arrow

        // if user pressed left and the position of player is still
        // within the x boundry then let it move left
        // and if user pressed right and the position of player is still
        // within the x boundry then let it move right
        if (hMove < 0)
        {
            if (currPosition.x >= xBoundryLeft)
            {
                transform.Translate(new Vector3(hMove * movePerSecond, 0 , 0));
            }
        }
        else if (hMove > 0)
        {
            if (currPosition.x <= xBoundryRight)
            {
                transform.Translate(new Vector3(hMove * movePerSecond, 0, 0));
            }
        }
        // if user pressed down and the position of player is still
        // within the y boundry then let is move it downward
        // and if user pressed up and the position of player is still
        // within the y boundry then let it move upward

        if (vMove < 0)
        {
            if (currPosition.y >= yBoundryBottom)
            {
                transform.Translate(new Vector3(0, vMove * movePerSecond, 0));
            }
        }
        else if (vMove > 0)
        {
            if (currPosition.y <= yBoundryTop)
            {
                transform.Translate(new Vector3(0, vMove * movePerSecond, 0));
            }
        }
    }
}
