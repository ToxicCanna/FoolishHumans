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

    [SerializeField] private TrailCheck trailCheck;
    [SerializeField] private TowerCheck buildTowerCheck; //bigger collider to see if something is too close
    [SerializeField] private TowerCheck upgradeTowerCheck; //smaller collider used to upgrade a tower

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
            if (trailCheck.IsAboveTrail())
            {
                return;
            }
            else if (upgradeTowerCheck.IsAboveTower())
            {
                upgradeOrDismantleMenu.SetActive(true);
            }
            else if (buildTowerCheck.IsAboveTower())
            {
                Debug.Log("too close");
            }
            else {
                buildMenu.SetActive(true);
            }
            //if nothing is around the player, open build menu
            


            //if tower is around the player, open upgradeOrDismantle menu
        }


    }
}
