using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public string enemyType = "Goblin";
    public int damage = 25;
    void Start()
    {
        Debug.Log("Enemy spawn:"+ enemyType);
        Debug.Log("Enemy damage:"+ damage);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
