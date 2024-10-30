using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCheck : MonoBehaviour
{
    //should have a small collider
    private bool foundTower;
    [SerializeField] private Tower _currentTowerObject;

    private void Start()
    {
        _currentTowerObject = null;
        foundTower = false;
    }

    public void Reset()
    {
        _currentTowerObject = null;
        foundTower = false;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Tower"))
        {
            if (_currentTowerObject == null)
            {
                _currentTowerObject = other.gameObject.GetComponent<Tower>();
                foundTower = true;
            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Tower"))
        {
            _currentTowerObject = null;
            foundTower = false;
        }
    }

    public bool IsAboveTower()
    {
        return foundTower;
    }

    public Tower getTower()
    {
        return _currentTowerObject;
    }
}
