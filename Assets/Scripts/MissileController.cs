using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileController : MonoBehaviour
{
    // Start is called before the first frame update
    private int missileHealth;
    private float missileBlastDamage;
    private float missileBlastRadius;
    [SerializeField]
    private float speed = 1;
    private Transform target;

    public enum State
    {
        idle,
        attacking,
        launching,
    }
    [SerializeField]
    private State currentState;

    private Transform planetTransform;
    private void Awake()
    {
        planetTransform = GameObject.Find("Planet(Clone)").transform; 
    }

    void Start()
    {
        if (planetTransform == null)
        {
            planetTransform = GameObject.Find("Planet(Clone)").transform;
        }
        if (planetTransform == null)
        {
            Debug.Log("Error! missile cannot exist without planet!");
            return;
        }
        if(transform.parent != planetTransform)
        {
            transform.SetParent(planetTransform);//Set the planet transform to be the parent of the missile
        }
    }

    private void FixedUpdate()
    {
        if(currentState == State.attacking)
        {
            Attacking();
            return;
        }
        if(currentState == State.launching)
        {
            Launching();
            return;
        }
        IdleAction();
    }

    //Missile behaviour methods:
    public void SetState(State state)
    {
        currentState = state;
    }
    public State CurrentState()
    {
        return currentState;
    }

    private void Attacking()
    {
        if (target == null)
        {
            target = GameObject.Find("Planet(Clone)").transform;
        }
        transform.LookAt(target);//Point towards asteroid centre
        transform.position = transform.position + (transform.forward * speed * Time.deltaTime); //Move forwards speed*Time.deltaTime
    }
    private void Launching()
    {
        //Point away from asteroid centre
        //Move forwards speed*Time.deltaTime
        //Check if left planet radius. If so add to missile tracker and destroy game object
    }
    private void IdleAction()
    {
        //Do nothing
    }

    public void OnSelfDestruct()
    {
        //A method by which a player can self-destruct a missile.
    }

    //Missile basic methods:
    public int GetHealth()
    {
        return missileHealth;
    }
    public float GetDamage()
    {
        return missileBlastDamage;
    }
    public float GetBlastRadius()
    {
        return missileBlastRadius;
    }
    public float GetSpeed()
    {
        return speed;
    }
    public void SetHealth(int health)
    {
        missileHealth = health;
    }
    public void SetDamage(float damage)
    {
        missileBlastDamage = damage;
    }
    public void SetRadius(float rad)
    {
        missileBlastRadius = rad;
    }
    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
}
