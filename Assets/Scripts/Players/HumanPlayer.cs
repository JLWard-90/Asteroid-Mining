using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanPlayer : Player
{
    BuildingManager buildManager;
    BuildingPlacement buildPlacement;
    // Start is called before the first frame update
    void Start()
    {
        buildManager = new BuildingManager();
        buildPlacement = new BuildingPlacement();
    }

    public void InitialisePlayer(string playerName,int playerNumber, int cash)
    {
        this.playerName = playerName;
        this.playerNumber = playerNumber;
        playerCash = cash;
        buildManager = this.gameObject.AddComponent<BuildingManager>();
        buildPlacement = this.gameObject.AddComponent<BuildingPlacement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
