using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public static playerMove instance;

    public float hInput = 10.0f;
    public float vInput = 12.0f;
    public float movementSpeed = 10.0f;
    public float rotationSpeed = 10f;
    public int health = 6;

    Vector2 reticlePos;
    public Camera cam;
    private Rigidbody2D playerRB;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
       playerRB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        CheckInput();
    }

    private void FixedUpdate()
    {
        ApplyMovement();
    }

    private void CheckInput()
    {
        hInput = Input.GetAxisRaw("Horizontal");
        vInput = Input.GetAxisRaw("Vertical");

        // tracks where the mouse is on screen
        reticlePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void ApplyMovement()
    {
        // makes player move relative to game world rather than rotation
        transform.Translate(Vector2.right * Time.deltaTime * movementSpeed * hInput, Space.World);
        transform.Translate(Vector2.up * Time.deltaTime * movementSpeed * vInput, Space.World);

        // rotates player according to reticle position
        Vector2 orientation = reticlePos - playerRB.position;
        float angle = Mathf.Atan2(orientation.y, orientation.x) * Mathf.Rad2Deg - 90f;
        playerRB.rotation = angle;
    }
}