using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private GameObject playerGameObject;
    [SerializeField] public Camera cam;
    private void FixedUpdate()
    {
        Vector3 screenPos = cam.WorldToScreenPoint(playerGameObject.transform.position);
        //Debug.Log(screenPos);
        Vector3 worldPos = cam.ScreenToWorldPoint(screenPos);
        float zPos =  Mathf.Clamp(worldPos.z, -10f, 12f);
        Vector3 uiPos = new Vector3(Mathf.Clamp(worldPos.x, -0.118182f * zPos - 15f  , 0.263636f * zPos + 16f), worldPos.y, zPos); //uhhhh
        transform.position = uiPos;
    }

    public void BuildTower(int tower)
    {
        GameManager.Instance.BuildTower((SpawnableTowers)tower);
    }
}
