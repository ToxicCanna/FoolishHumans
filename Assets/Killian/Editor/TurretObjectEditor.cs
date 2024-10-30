using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TurretObject))]
public class TurretObjectEditor : Editor
{
    public override void OnInspectorGUI()
    {
        TurretObject turret = (TurretObject)target;

        // Slider for atkSpd
        turret.atkSpd = EditorGUILayout.IntSlider("Attack Speed (1-100)", turret.atkSpd, 1, 100);

        // Calculate attack time based on the formula
        float attackTime = 1 / (turret.atkSpd / 50f);

        // Display the attack time in seconds
        EditorGUILayout.LabelField("Seconds between attacks", attackTime.ToString("F2"));

        // Input field for custom attack time
        float customAttackTime = EditorGUILayout.FloatField("Set Attack Time (seconds)", attackTime);

        // Adjust the slider based on custom attack time
        if (customAttackTime > 0)
        {
            turret.atkSpd = Mathf.RoundToInt(50f / customAttackTime);
            turret.atkSpd = Mathf.Clamp(turret.atkSpd, 1, 100); // Clamp the value between 1 and 100
        }

        // Display the updated attack speed
        EditorGUILayout.LabelField("Calculated Attack Speed (1-100)", turret.atkSpd.ToString());

        // Other fields
        turret.atkDmg = EditorGUILayout.IntField("Attack Damage", turret.atkDmg);
        turret.range = EditorGUILayout.FloatField("Range", turret.range);
        turret.area = EditorGUILayout.FloatField("Area", turret.area);
        turret.chain = EditorGUILayout.IntField("Chain", turret.chain);
        turret.cost = EditorGUILayout.IntField("Cost", turret.cost);
        turret.level = EditorGUILayout.IntField("Level", turret.level);

        // Save changes
        if (GUI.changed)
        {
            EditorUtility.SetDirty(turret);
        }
    }
}
