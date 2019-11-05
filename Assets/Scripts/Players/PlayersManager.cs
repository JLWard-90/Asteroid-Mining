using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersManager : MonoBehaviour
{
    public GameObject humanPlayerPrefab;
    public Player[] thePlayers;
    public int numberOfPlayers;
    public int startingCash;
    // Start is called before the first frame update
    void Start()
    {
        SpawnHumanPlayer();
    }

    public GameObject SpawnHumanPlayer()
    {
        GameObject humanPlayer = GameObject.Instantiate(humanPlayerPrefab);
        humanPlayer.GetComponent<HumanPlayer>().InitialisePlayer("Player One", 0, startingCash);
        return humanPlayer;
    }
}
