using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollideDestroy : MonoBehaviour
{
    [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    [SerializeField] string destroyTag;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == destroyTag && enabled)
        {
            //Destory the collide object
            Destroy(other.gameObject);
        }
    }
}
