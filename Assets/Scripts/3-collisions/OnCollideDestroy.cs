using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollideDestroy : MonoBehaviour
{
    [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    [SerializeField] string destroyTag;
    readonly float delay_before_destroy = 0.75f;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == destroyTag && enabled)
        {
            other.GetComponent<ParticleSystem>().Play();

            //Destory the collide object
            other.GetComponent<Renderer>().enabled = false;//Hide the object
            Destroy(other.gameObject, delay_before_destroy);//Destroy with delay
        }
    }
}
