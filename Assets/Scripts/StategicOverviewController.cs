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
        //Debug.Log("left mouse click");
        RaycastHit hit;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);//screen to raycast
        if (Physics.Raycast(ray, out hit))
        {
            //Debug.Log("hit");
            //Debug.Log(hit.distance);
            if (hit.collider.gameObject.tag == "astRep") //If hit asteroid rep
            {
                //If an asteroid was already selected, deselect it:
                int oldIndex = navManager.selectedAsteroidIndex;
                //Color deselect = new Color(0.389f, 0.389f, 0.389f); //Grey
                astManager.astRepList[oldIndex].GetComponent<astRepControl>().OnDeselect(); // GetComponentInChildren<SpriteRenderer>().color = deselect;
                //Set selected asteroid in navigation controller to that asteroid rep's index
                int asteroidIndex = hit.collider.gameObject.GetComponent<astRepControl>().index;
                navManager.selectedAsteroidIndex = asteroidIndex;
                //Change asteroid rep colour
                hit.collider.gameObject.GetComponent<astRepControl>().OnSelect(hit.collider.gameObject.GetComponentInChildren<SpriteRenderer>().color);
            }
        }
    }

    private void OnRightMouseClick()
    {
        RaycastHit hit;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);//screen to raycast
        if (Physics.Raycast(ray, out hit))
        {
            //Debug.Log("hit");
            //Debug.Log(hit.distance);
            if (hit.collider.gameObject.tag == "astRep") //If hit asteroid rep
            {
                //If an asteroid was already selected, deselect it:
                int oldIndex = navManager.selectedAsteroidIndex;
                astManager.astRepList[oldIndex].GetComponentInChildren<SpriteRenderer>().color = new Color(100, 100, 100);
                //Set selected asteroid in navigation controller to that asteroid rep's index
                int asteroidIndex = hit.collider.gameObject.GetComponent<astRepControl>().index;
                navManager.selectedAsteroidIndex = asteroidIndex;
                navManager.LoadAsteroidView();
            }
        }
    }

    //On Left Mouse button double-click
    //Screen to raycast
    //If hit asteroid rep
    //Set selected asteroid in navigation controler to asteroid rep's index
    //Load asteroid
}
