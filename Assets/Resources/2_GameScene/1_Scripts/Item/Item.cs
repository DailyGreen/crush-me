using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    SpriteRenderer ItemSr;
    CircleCollider2D ItemCol;

    public float speed;
    public Vector2 destination;

    void Start()
    {
        ItemSr = GetComponent<SpriteRenderer>();
        ItemCol = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        transform.Translate(destination * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Hero"))
        {
            ItemSr.enabled = false;
            ItemCol.enabled = false;
        }
    }

}