using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICheckValidButton : MonoBehaviour
{
    [SerializeField] private int costForButtonAction;
    private Button myButton;

    [SerializeField] private bool isLevel3;
    [SerializeField] private TowerCheck spawningTowerCheck;
    [SerializeField] private Tower _currentTowerObject;

    public void setCost(int cost)
    {
        costForButtonAction = cost;
    }

    private void OnEnable()
    {
        myButton = GetComponent<Button>();
        _currentTowerObject = spawningTowerCheck.getTower();
        if (_currentTowerObject == null)
        {
            Debug.Log("this works");
        }
        else {
            if (!isLevel3)
            {
                switch ((int)_currentTowerObject.towerType)
                {
                    case 0:
                        //goblin
                        costForButtonAction = 200;
                        break;
                    case 1:
                        //frankenstiein
                        costForButtonAction = 1000;
                        break;
                    case 2:
                        //skeleton
                        costForButtonAction = 700;
                        break;
                    case 3:
                        //spider
                        costForButtonAction = 400;
                        break;
                    default:
                        Debug.Log("Incorrect intelligence level.");
                        break;
                }
            }
            else
            {
                switch ((int)_currentTowerObject.towerType)
                {
                    case 0:
                        //goblin
                        costForButtonAction = 500;
                        break;
                    case 1:
                        //frankenstiein
                        costForButtonAction = 2500;
                        break;
                    case 2:
                        //skeleton
                        costForButtonAction = 1500;
                        break;
                    case 3:
                        //spider
                        costForButtonAction = 1000;
                        break;
                    default:
                        Debug.Log("Incorrect intelligence level.");
                        break;
                }
            }
        }
        

        if (costForButtonAction > ScoreManager.Instance.GetBlood())
        {
            myButton.interactable = false;
        }
        else
        {
            myButton.interactable = true;
        }

    }
}
