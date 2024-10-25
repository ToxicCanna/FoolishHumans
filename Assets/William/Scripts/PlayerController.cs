using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Singleton<PlayerController>
{
    [SerializeField] private float speed;
    [SerializeField] private float rotateSpeed;
    private Rigidbody rb;
    private Vector3 movementVector;
    private Vector3 previousPosition;
    private Vector3 currentPosition;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = movementVector * speed;
        if (rb.velocity != Vector3.zero)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(transform.position - previousPosition), Time.deltaTime * rotateSpeed);
        }
    }

    public void OnMove(Vector2 MovementValue)
    {
        previousPosition = currentPosition;
        currentPosition = transform.position;
        Debug.Log(MovementValue);
        movementVector.x = MovementValue.x;
        movementVector.z = MovementValue.y;
    }
}
