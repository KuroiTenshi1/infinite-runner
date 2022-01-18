using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformScripts : MonoBehaviour
{
    public float speed = 3.0f;
    
    private Rigidbody2D _rb;

    public GameObject Menu;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var velocity = _rb.velocity;
        velocity = new Vector2(-speed, velocity.y);
        _rb.velocity = velocity;
    }
}