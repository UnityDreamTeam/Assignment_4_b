using UnityEngine;

/**
 * This component moves its object when the player clicks the arrow keys.
 * It's movement is based on rigitbody components in order to use natural physics
 * when colliding walls objects
 */
public class KeyboardMover: MonoBehaviour {
    [Tooltip("Speed of movement, in meters per second")]
    [SerializeField] float speed = 1f;
    [SerializeField] Rigidbody2D rb2D;

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal"); // +1 if right arrow is pushed, -1 if left arrow is pushed, 0 otherwise
        float vertical = Input.GetAxis("Vertical");     // +1 if up arrow is pushed, -1 if down arrow is pushed, 0 otherwise
        Vector2 movementVector = new Vector2(horizontal, vertical) * speed * Time.fixedDeltaTime;

        //Update rigidbody position based on movement vector
        rb2D.MovePosition(rb2D.position + movementVector + rb2D.velocity * Time.fixedDeltaTime);
    }
}
