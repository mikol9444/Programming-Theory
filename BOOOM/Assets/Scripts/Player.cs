using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; set; }

    [SerializeField] protected GameObject bombPrefab;
    protected Vector3 intPosition
    {
        get { return new Vector3(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y), Mathf.RoundToInt(transform.position.z)); }
        private set { }
    }
    
    [SerializeField][Range(0,20)] protected float speed = 2.5f;
    public float Speed {get { return speed; }set { if (speed < 6) speed = value; }}
    [SerializeField] [Range(0, 20)] protected int explosionRange;
    public int ExplosionRange { get { return explosionRange; } set { if (explosionRange < 20) explosionRange = value; } }
    protected Rigidbody2D rb;

    
    void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        intPosition = new Vector3(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y), Mathf.RoundToInt(transform.position.z));
            
    }
}
