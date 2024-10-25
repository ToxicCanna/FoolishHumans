using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "TurretObject", menuName = "ScriptableObjects/TurretObject", order = 1)]
public class TurretObject : ScriptableObject
{
    public float atkSpd;
    public float atkDmg;
    public float range;
    public float area;
    public float chain;
    public int cost;
    public int level = 1;
}
