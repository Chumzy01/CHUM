//THIS SCRIPT IS TO BE ADDED TO YOUR BULLET GAMEOBJECT.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    //Assignables
    public Rigidbody rb;
    public GameObject explosion;
    public LayerMask whatIsEnemy;

    //stats
    [Range(0f, 1f)]
    public float bounciness;
    public bool useGravity;

    public int explosionDamage;
    public float explosionRange;
    

    //Lifetime for bullet
    public int maxCollisions;
    public float maxLifeTime;
    public bool explodeOnTouch = true;

    int collisions;
    PhysicMaterial physicsMat;

    private void Start()
    {
        Setup();
    }

    private void Update()
    {
        //When to explode
        if(collisions > maxCollisions)
        {
            Explode();

            //Count down lifetime
            maxLifeTime -= Time.deltaTime;
            if(maxLifeTime <= 0)
            {
                Explode();
            }
        }

    }

    private void Explode()
    {
        //Instantiate explosion
        if(explosion != null)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
        }

        //Check for enemies around range of bullet

        Collider[] enemies = Physics.OverlapSphere(transform.position, explosionRange, whatIsEnemy);
        for (int i = 0; i < enemies.Length; i++)
        {
            //Get the component of enemy to take damage
        }

        //Add delay before destroying bullet
        Invoke("Delay",0.05f);
    }

    private void Delay()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision other) {
        // If you DO NOT want to count collision with other bullets
        if(collision.collider.CompareTag("Bullet"))
        {
            return;
        }

        //count up collisions
        collisions++;

        //Explode if bullet hits an enemy directly and explodeOnTouch is activated
        if(other.collider.CompareTag("Enemy") && explodeOnTouch)
        {
            Explode();
        }
    }

    private void Setup()
    {
        // Create a new Physics material
        physicsMat = new PhysicMaterial();
        physicsMat.bounciness = bounciness;
        physicsMat.frictionCombine = PhysicMaterialCombine.Minimum;
        physicsMat.bounceCombine = PhysicMaterialCombine.Maximum;

        //Assign material to collider
        GetComponent<SphereCollider>().material = physicsMat;

        //set gravity
        rb.useGravity = useGravity;
    }
}
