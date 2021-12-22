using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckInput : Player
{

    // Start is called before the first frame update
    Vector2 movement;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * Speed;
        if (Input.GetKeyDown(KeyCode.H))
        {
            SetBomb();
        }
    }
    private void FixedUpdate()
    {
        if (movement != Vector2.zero)
        {
            rb.velocity = movement;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    public void SetBomb()
    {
        Instantiate(bombPrefab, intPosition, Quaternion.identity);
    }
}
