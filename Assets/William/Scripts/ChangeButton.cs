using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeButton : MonoBehaviour
{
    [SerializeField] private UIIconScriptableObject goblinUI;
    [SerializeField] private UIIconScriptableObject spiderUI;
    [SerializeField] private UIIconScriptableObject frankensteinUI;
    [SerializeField] private UIIconScriptableObject skeletonUI;

    [SerializeField] private GameObject buttonOneImage;
    [SerializeField] private GameObject buttonTwoImage;

    [SerializeField] private TowerCheck spawningTowerCheck;
    [SerializeField] private Tower _currentTowerObject;

    private void OnEnable()
    {
        _currentTowerObject = spawningTowerCheck.getTower();
        switch((int)_currentTowerObject.towerType)
        {
            case 0:
                buttonOneImage.GetComponent<Button>().image.sprite = goblinUI.iconPathA;
                buttonTwoImage.GetComponent<Button>().image.sprite = goblinUI.iconPathB;
                break;
            case 1:
                buttonOneImage.GetComponent<Button>().image.sprite = frankensteinUI.iconPathA;
                buttonTwoImage.GetComponent<Button>().image.sprite = frankensteinUI.iconPathB;
                break;
            case 2:
                buttonOneImage.GetComponent<Button>().image.sprite = skeletonUI.iconPathA;
                buttonTwoImage.GetComponent<Button>().image.sprite = skeletonUI.iconPathB;
                break;
            case 3:
                buttonOneImage.GetComponent<Button>().image.sprite = spiderUI.iconPathA;
                buttonTwoImage.GetComponent<Button>().image.sprite = spiderUI.iconPathB;
                break;
            default:
                Debug.Log("Incorrect intelligence level.");
                break;
        }

    }
}
