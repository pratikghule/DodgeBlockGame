using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 15f;
    public float mapwidth = 5f;

    private Rigidbody2D rb;
    

    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.GetComponent<Renderer>().material.color = Color.yellow;

    }

    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * speed;
        Vector2 newPosition = rb.position + Vector2.right * x;
        newPosition.x = Mathf.Clamp(newPosition.x,-mapwidth,mapwidth);
        rb.MovePosition(newPosition);
        
    }

    void OnCollisionEnter2D()
    {
        FindObjectOfType<GameManager>().EndGame();
    }
}
