using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersManager : MonoBehaviour
{
    public GameObject humanPlayerPrefab;
    public Player[] thePlayers;
    public int numberOfPlayers;
    public int startingCash;
    GameObject gameControllerObject;
    // Start is called before the first frame update
    void Start()
    {
        gameControllerObject = GameObject.Find("GameController");
        SpawnHumanPlayer();
    }

    public GameObject SpawnHumanPlayer()
    {
        GameObject humanPlayer = GameObject.Instantiate(humanPlayerPrefab);
        humanPlayer.GetComponent<HumanPlayer>().InitialisePlayer("Player One", 0, startingCash);
        humanPlayer.transform.SetParent(gameControllerObject.transform);
        return humanPlayer;
    }
}
