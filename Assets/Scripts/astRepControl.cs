using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class astRepControl : MonoBehaviour
{
    public int index;
    public bool selected;
    private float timestep = 0.2f;
    private float timer = 0;
    private Color baseColour = new Color(0.389f, 0.389f, 0.389f); //Grey;
    private bool colSwitch = true;
    private void Update()
    {
        if (selected)
        {
            timer += Time.deltaTime;
            if (timer >= timestep)
            {
                timer = 0;
                if (colSwitch)
                {
                    gameObject.GetComponentInChildren<SpriteRenderer>().color = new Color(255, 255, 255); //Set colour to white
                    colSwitch = false;
                }
                else
                {
                    gameObject.GetComponentInChildren<SpriteRenderer>().color = baseColour;
                    colSwitch = true;
                }
            }
        }
    }

    public void OnDeselect()
    {
        selected = false;
        if (baseColour == null)
        {
            baseColour = new Color(0.389f, 0.389f, 0.389f); //Grey
        }
        gameObject.GetComponentInChildren<SpriteRenderer>().color = baseColour;
    }

    public void OnSelect(Color baseColor)
    {
        selected = true;
    }
}
