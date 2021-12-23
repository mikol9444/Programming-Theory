using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class ontrigger : MonoBehaviour
{
    public AstarPath astar;
    private void OnTriggerEnter2D(Collider2D collision)
    {
           if (collision.gameObject.CompareTag("Enemy"))
        {
            astar.Scan();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            gameObject.SetActive(false);
        }
    }*/
}
