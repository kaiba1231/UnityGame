using UnityEngine;

public class Player : MonoBehaviour
{   
    public int playercurrency = 500;
    public int playerlevel = 3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Player start");
        Debug.Log("Playergold:" + playercurrency);
        Debug.Log("bat dau di chuyen:");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
