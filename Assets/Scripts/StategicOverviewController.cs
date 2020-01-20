using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StategicOverviewController : MonoBehaviour
{
    NavManager navManager;
    AsteroidManager astManager;
    private void Start()
    {
        navManager = GameObject.Find("NavigationManager").GetComponent<NavManager>();
        astManager = GameObject.Find("GameController").GetComponent<AsteroidManager>();
    }
    
    private void Update()
    {
        MouseHandler();   
    }

    private void MouseHandler()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Left click
            OnLeftMouseClick();
        }
        else if (Input.GetMouseButtonDown(1))
        {
            OnRightMouseClick();
        }
    }

    
    private void OnLeftMouseClick()//On Left Mouse button click:
    {
        Debug.Log("left mouse click");
        RaycastHit hit;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);//screen to raycast
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("hit");
            Debug.Log(hit.distance);
            if (hit.collider.gameObject.tag == "astRep") //If hit asteroid rep
            {
                //If an asteroid was already selected, deselect it:
                int oldIndex = navManager.selectedAsteroidIndex;
                astManager.astRepList[oldIndex].GetComponentInChildren<SpriteRenderer>().color = new Color(255, 255, 255);
                //Set selected asteroid in navigation controller to that asteroid rep's index
                int asteroidIndex = hit.collider.gameObject.GetComponent<astRepControl>().index;
                navManager.selectedAsteroidIndex = asteroidIndex;
                //Change asteroid rep colour
                Color newColor = new Color(255, 0, 0); //RED
                hit.collider.gameObject.GetComponentInChildren<SpriteRenderer>().color = newColor;
            }
        }
    }

    private void OnRightMouseClick()
    {

    }

    //On Left Mouse button double-click
    //Screen to raycast
    //If hit asteroid rep
    //Set selected asteroid in navigation controler to asteroid rep's index
    //Load asteroid
}
