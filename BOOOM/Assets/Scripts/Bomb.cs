using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private CheckInput checkInputScript;
    private Animator anim;
    private Transform tr;
    public LayerMask layerMask;
    bool explosionTime;
    int explosionRange;
    // Start is called before the first frame update
    void Start()
    {
        checkInputScript = GameObject.FindGameObjectWithTag("Player").GetComponent<CheckInput>();
        anim = GetComponent<Animator>();
        tr = GetComponent<Transform>();
        explosionTime = false;
         explosionRange = Player.Instance.ExplosionRange;
    }

    // Update is called once per frame
    void Update()
    {
        if (explosionTime) CastExplosion();
    }
    public void SetTrigger()
    {
        explosionTime = true;
        anim.SetBool("exploded",true);

        
    }
    public void setScale()
    {
        
        transform.localScale = new Vector3(explosionRange, explosionRange, 1);
    }

    public void CastExplosion()
    {
             
             Destroy(gameObject, 2f);
            RaycastHit2D hit = Physics2D.BoxCast(transform.position, new Vector3(10,10,1), 0, Vector2.zero, 1, layerMask);
            if (hit.collider)
            {
            checkInputScript.EnemyCollision();
                Destroy(hit.collider.gameObject);
            }
    }
}
