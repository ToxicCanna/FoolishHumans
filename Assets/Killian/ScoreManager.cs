using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{

    public int blood; //Player's money

    public void AddBlood(int amount)
    {
        blood += amount;
        Debug.Log("Blood: " + blood);
    }

    public void PayBlood(int amount)
    {
        blood -= amount;
        Debug.Log("Blood: " + blood);
    }

    public int GetBlood()
    {
        return blood;
    }
}
