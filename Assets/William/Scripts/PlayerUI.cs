using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private GameObject playerGameObject;
    [SerializeField] public Camera cam;
    [SerializeField] private GameObject buildMenu;
    [SerializeField] private GameObject upgradeOrDismantleMenu;
    [SerializeField] private GameObject maxUpgradeMenu;
    private void FixedUpdate()
    {

    }

    public void BuildTower(int tower)
    {
        Debug.Log("buttonclicked");
        buildMenu.SetActive(false);
        upgradeOrDismantleMenu.SetActive(false);
        maxUpgradeMenu.SetActive(false);

        GameManager.Instance.BuildTower((SpawnableTowers)tower);

    }
}
