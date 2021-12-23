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
    public int ExplosionRange { get { return explosionRange; } set { explosionRange = value; } }
    protected Rigidbody2D rb;
    protected int highScore = 0;
    public int HighScore { get { return highScore; } set { highScore = value; } }
    public int exp=0;
    public int Exp { get { return exp; } set { exp = value%20; } }


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
