using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private TowerCheck towerCheck;
    [SerializeField] private TowerCheck toReset;
    [SerializeField] public Camera cam;
    [SerializeField] private GameObject buildMenu;
    [SerializeField] private GameObject upgradeOrDismantleMenu;
    [SerializeField] private GameObject maxUpgradeMenu;
    private Tower selectedTower;
    private void FixedUpdate()
    {

    }

    public void BuildTower(int tower)
    {
        CloseMenus();

        GameManager.Instance.BuildTower((SpawnableTowers)tower);

    }

    public void UpgradeTower()
    {
        CloseMenus();
        SelectTower();
        if (selectedTower.GetLevel() < 2)
        {
            selectedTower.Upgrade();
        }
        else if(selectedTower.GetLevel() == 2)
        {
            maxUpgradeMenu.SetActive(true);
        }
    }

    public void MaxUpgradeTower(int i)
    {
        CloseMenus();
        if (i == 1)
        {
            selectedTower.SetPath1();
        }else if (i == 2)
        {
            selectedTower.SetPath2();
        }
    }

    public void DismantleTower()
    {
        CloseMenus();
        SelectTower();
        Destroy(selectedTower.gameObject);
        selectedTower = null;
        toReset.Reset();
        towerCheck.Reset();
    }

    public void CloseMenus()
    {
        buildMenu.SetActive(false);
        upgradeOrDismantleMenu.SetActive(false);
        maxUpgradeMenu.SetActive(false);
    }

    public void SelectTower()
    {
        selectedTower = towerCheck.getTower();

    }


}
