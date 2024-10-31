using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayHP : MonoBehaviour
{
    public TMP_Text text;

    // Update is called once per frame
    void FixedUpdate()
    {
        text.text = "HP: " + CastleScript.Instance.GetHealth();
    }
}
