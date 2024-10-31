using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "TurretObject", menuName = "ScriptableObjects/TurretObject", order = 1)]
public class TurretObject : ScriptableObject
{
  [Range(1,100)] public int atkSpd;
    public int atkDmg;
    public float range;
    public float area;
    public int chain;
    public int cost;
    public int level = 1;
}
