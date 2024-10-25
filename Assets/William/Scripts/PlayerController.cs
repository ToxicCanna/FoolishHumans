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
    [SerializeField] private GameObject buildMenu;
    [SerializeField] private GameObject upgradeOrDismantleMenu;
    [SerializeField] private GameObject maxUpgradeMenu;
    private bool isMoving;
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
            isMoving = true;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(transform.position - previousPosition), Time.deltaTime * rotateSpeed);
        }
        else
        {
            isMoving = false;
        }
    }

    public void OnMove(Vector2 MovementValue)
    {
        buildMenu.SetActive(false);
        upgradeOrDismantleMenu.SetActive(false);
        maxUpgradeMenu.SetActive(false);

        previousPosition = currentPosition;
        currentPosition = transform.position;
        
        movementVector.x = MovementValue.x;
        movementVector.z = MovementValue.y;
    }

    public void OnOpenUI()
    {
        if (!isMoving)
        {
            //if nothing is around the player, open build menu
            buildMenu.SetActive(true);


            //if tower is around the player, open upgradeOrDismantle menu
        }


    }
}
