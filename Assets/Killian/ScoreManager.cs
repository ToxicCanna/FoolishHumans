using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int blood; //Player's money

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddBlood(int amount)
    {
        blood += amount;
        Debug.Log("Blood: " + blood);
    }

    public int GetBlood()
    {
        return blood;
    }
}
