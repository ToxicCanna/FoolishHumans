using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayBlood : MonoBehaviour
{
    public TMP_Text text;

    // Update is called once per frame
    void FixedUpdate()
    {
        text.text = "" + ScoreManager.Instance.GetBlood();
    }
}
