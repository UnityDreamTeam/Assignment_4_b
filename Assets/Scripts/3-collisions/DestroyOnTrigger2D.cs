using UnityEngine;

/**
 * This component destroys its object whenever it triggers a 2D collider with the given tag.
 */
public class DestroyOnTrigger2D : MonoBehaviour {
    [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    [SerializeField] string triggeringTag;
    readonly float delay_before_destroy = 0.75f;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == triggeringTag && enabled) {
            //Enable laser's and enemy's collider in order to avoid destroying other objects
            other.GetComponent<Collider2D>().enabled = false;
            this.GetComponent<Collider2D>().enabled = false;

            this.GetComponent<ParticleSystem>().Play();
            other.GetComponent<ParticleSystem>().Play();
            this.GetComponent<Renderer>().enabled = false;
            other.GetComponent<Renderer>().enabled = false;
            
            Destroy(this.gameObject, delay_before_destroy);
            Destroy(other.gameObject, delay_before_destroy);
        }
    }
}
