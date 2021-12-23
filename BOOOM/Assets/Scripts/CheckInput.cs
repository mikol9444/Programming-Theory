using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckInput : Player
{

    
    // Start is called before the first frame update
    Vector2 movement;
    public Text text;
    public Text levelText;
    private float dashPower;
    private float rotationSpeed;
    private float level;

    void Start()
    {
        level = 0;
        rotationSpeed = 30;
        dashPower = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * Speed;
        if (Input.GetKeyDown(KeyCode.H))
        {
            SetBomb();
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            StartCoroutine(Dash());
        }


    }
    private void FixedUpdate()
    {
        if (movement != Vector2.zero)
        {
            rb.constraints = RigidbodyConstraints2D.None;
            rb.velocity = movement*dashPower;
            transform.Rotate(Vector3.forward * rotationSpeed);

        }
        else
        {
            rb.velocity = Vector2.zero;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }

    }

    public void SetBomb()
    {
        Instantiate(bombPrefab, intPosition, Quaternion.identity);
    }
    public IEnumerator Dash()
    {
        dashPower = 2;
        rb.AddForce(rb.velocity*dashPower, ForceMode2D.Impulse) ;
        yield return new WaitForSeconds(0.5f);
        dashPower = 1;
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyCollision();
            Destroy(collision.gameObject);

        }
    }
    private void ChooseAbility()
    {
        level++;
        levelText.text = $"level: {level}";
        Debug.Log("NEW ABIITY");
    }

    public void EnemyCollision()
    {
        Exp++;
        if (Exp == 0) ChooseAbility();
        highScore += 10;
        text.text = $"HighScore: {highScore}";
    }
}
