using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionMonsterBulletController : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Monster" || collisionInfo.gameObject.tag == "Bullet")
        {
            Physics2D.IgnoreCollision(collisionInfo.transform.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
        else
        {
            Destroy(gameObject);
            if (collisionInfo.gameObject.tag != "Wall")
            {
                Destroy(collisionInfo.gameObject);
            }
        }
    }
}
