using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleScript : Singleton<CastleScript>
{

    [SerializeField] private float castleHealth;
    [SerializeField] public Transform castleHurtbox;

    public void TakeDamage(float damage)
    {
        Debug.Log("Castle took damage: " + damage);
        castleHealth -= damage;
        if (castleHealth <= 0)
        {
            GameManager.Instance.GameOver();
        }
    }

    public float GetHealth()
    {
        return castleHealth;
    }
}
