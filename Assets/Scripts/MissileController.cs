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
    [SerializeField]
    GameObject explosionPrefab;
    private Transform target;
    public Camera missileCamera;
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
        missileCamera = this.gameObject.GetComponentInChildren<Camera>();
        missileCamera.enabled = false;
        CameraManager cameraManager = GameObject.Find("GameController").GetComponent<CameraManager>();
        if (cameraManager != null)
        {
            cameraManager.AddCamera(missileCamera);
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
        CheckImpact();
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

    public void CheckImpact()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward *0.01f , out hit))
        {
            if (hit.rigidbody != null && hit.distance < 0.02f)
            {
                Debug.Log(hit.transform.gameObject);
                Debug.Log("Missile explodes");
                if (explosionPrefab != null)
                {
                    GameObject newExplosion = GameObject.Instantiate(explosionPrefab);
                    newExplosion.transform.position = transform.position;
                }
                else
                {
                    Debug.Log("MissileController::CheckImpact -- Explosion prefab missing!");
                }
                GameObject.Destroy(this.gameObject);
            }
        }
    }
}
