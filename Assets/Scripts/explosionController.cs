using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionController : MonoBehaviour
{
    [SerializeField]
    float timescale = 4;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("Planet(Clone)") != null)
        {
            transform.SetParent(GameObject.Find("Planet(Clone)").transform);
        }
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > timescale)
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
