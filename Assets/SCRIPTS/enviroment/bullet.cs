using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {

    public enum BulletType
    {
        RIFLE,
        SHOTGUN
    }

    public int damage = 0;

    public BulletType bulletTupe;

    public void blast(Vector3 force)
    {
        GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("projectile") && !other.CompareTag("ignorable"))
        {
            //if the player or another projectile then do some stuff
            if (other.gameObject.CompareTag("Player"))
            {
                other.gameObject.GetComponent<playerHealth>().health -= damage;
            }
            if (other.gameObject.CompareTag("enemy"))
            {
                other.gameObject.GetComponent<enemyHealth>().health -= damage;
            }

            Destroy(this.gameObject);
        }
    }
}
