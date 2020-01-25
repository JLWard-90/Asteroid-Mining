using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersManager : MonoBehaviour
{
    public GameObject humanPlayerPrefab;
    public List<GameObject> thePlayers;
    public int numberOfAIPlayers;
    public int startingCash;
    GameObject gameControllerObject;
    // Start is called before the first frame update
    void Start()
    {
        if (thePlayers == null)
        {
            thePlayers = new List<GameObject>();
        }
        gameControllerObject = GameObject.Find("GameController");
        thePlayers.Add(SpawnHumanPlayer()); //In the future, this will need to be adapted to handle a loaded game. i.e. only do this if the game is a new one.
    }

    public GameObject SpawnHumanPlayer()
    {
        GameObject humanPlayer = GameObject.Instantiate(humanPlayerPrefab);
        humanPlayer.GetComponent<HumanPlayer>().InitialisePlayer("Player One", 0, startingCash);
        humanPlayer.transform.SetParent(gameControllerObject.transform);
        humanPlayer.name = "humanPlayer";
        return humanPlayer;
    }
}
