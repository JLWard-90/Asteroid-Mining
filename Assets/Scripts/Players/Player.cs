using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    protected int playerCash; //Amount of currency held by player
    protected int playerNumber;
    protected string playerName;
    public bool isHuman;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.AddComponent<HumanPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
    //Generic player functions:
    public int getCash()
    {
        return playerCash;
    }
    public int getPlayerNumber()
    {
        return playerNumber;
    }
    public void AddCash(int cash)
    {
        this.playerCash += cash;
    }
    public string getPlayerName()
    {
        return playerName;
    }

    public void InitialisePlayer()
    {
        Debug.Log("Player needs to be human or AI!");
    }
}
