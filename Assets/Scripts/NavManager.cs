using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavManager : MonoBehaviour
{
    public void OnTestButtonPush()
    {
        SceneManager.LoadScene("AsteroidScene");
    }
}
