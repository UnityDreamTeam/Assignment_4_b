using UnityEngine;

/**
 * This component moves its object when the player clicks the arrow keys.
 * It's movement is based on rigitbody components in order to use natural physics
 * when colliding walls objects
 */
public class SpaceMover1 : MonoBehaviour
{
    [Tooltip("Speed of movement, in meters per second")]
    [SerializeField] float speed = 1f;

    void Update()
    {
        Vector3 pos = transform.position;
        float horizontal = Input.GetAxis("Horizontal"); // +1 if right arrow is pushed, -1 if left arrow is pushed, 0 otherwise
        float vertical = Input.GetAxis("Vertical");     // +1 if up arrow is pushed, -1 if down arrow is pushed, 0 otherwise
        Vector3 movementVector = new Vector3(horizontal, vertical, 0) * speed * Time.deltaTime;

        //Wrap check
        pos.x = Mathf.Repeat(pos.x, CalculateHalfScreenSize() * 2);

        transform.position = pos;
        transform.position += movementVector;
    }

    float CalculateHalfScreenSize()
    {
        float aspect = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().aspect;
        float ortoSize = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().orthographicSize;
        return aspect * ortoSize;
    }
}
