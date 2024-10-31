using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UIIcon", menuName = "ScriptableObjects/UIIcons", order = 1)]
public class UIIconScriptableObject : ScriptableObject
{
    [SerializeField] public Sprite iconPathA;
    [SerializeField] public Sprite iconPathB;
}
