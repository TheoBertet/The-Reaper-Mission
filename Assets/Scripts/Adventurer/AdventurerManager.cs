using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventurerManager : MonoBehaviour
{
    public float speed = 2;
    public bool playerDetected = false;
    public GameObject attackAnimation;
    public float attackCooldown = 2f;
    public float rangeAttack = 1f;
    public float healthpoints = 1;
    public float curHP = 0;
    public float damages = 1;

    public Transform[] waypoints;

    private Rigidbody2D rigidbody;
    private int numWaypoint = 0;
    private float attackTimeStart = 0f;

    // Start is called before the first frame update
    void Start()
    {
        LoadPathfinding();
        rigidbody = transform.GetComponent<Rigidbody2D>();
        curHP = healthpoints;
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.velocity = new Vector2(0, 0);
        if (Time.time > attackTimeStart + attackCooldown)
        {
            Move();
            if(playerDetected)
                Attack();
        }

        if(curHP <= 0)
        {
            Die();
        }
    }

    public void Attack()
    {
        if (Vector3.Distance(transform.position, GameObject.Find("Player").transform.position) <= rangeAttack)
        {
            GameObject player = GameObject.Find("Player");

            GameObject animation = Instantiate(attackAnimation);
            animation.transform.position = player.transform.position;

            player.GetComponent<PlayerManager>().Damage(damages);

            attackTimeStart = Time.time;

            if(player.GetComponent<PlayerManager>().isDead())
            {
                playerDetected = false;
            }
        }
    }

    public void Move()
    {
        float targetX = transform.position.x;
        float targetY = transform.position.y;
        float posX = transform.position.x;
        float posY = transform.position.y;
        float moveVertical = 0;
        float moveHorizontal = 0;
        float marginDistance;

        if (!playerDetected)
        {
            marginDistance = 0.1f;
            if (waypoints.Length > 0 && numWaypoint < waypoints.Length)
            {
                targetX = waypoints[numWaypoint].position.x;
                targetY = waypoints[numWaypoint].position.y;

                if (Math.Abs(Math.Abs(targetX) - Math.Abs(posX)) <= 0.5 && Math.Abs(Math.Abs(targetY) - Math.Abs(posY)) <= 0.5)
                {
                    numWaypoint++;
                }
            }
        }
        else
        {
            marginDistance = 0.5f;
            GameObject player = GameObject.Find("Player");
            targetX = player.transform.position.x;
            targetY = player.transform.position.y;
        }


        if (posX < targetX - marginDistance)
        {
            moveVertical = 1 * speed;
        }
        else if (posX > targetX + marginDistance)
        {
            moveVertical = -1 * speed;
        }

        if (posY < targetY - marginDistance)
        {
            moveHorizontal = 1 * speed;
        }
        else if (posY > targetY + marginDistance)
        {
            moveHorizontal = -1 * speed;
        }

        rigidbody.velocity = new Vector2(moveVertical, moveHorizontal);
    }

    public void DetectPlayer()
    {
        playerDetected = true;
    }

    public void Damage(float damage)
    {
        curHP -= damage;
    }

    public void LoadPathfinding()
    {
        Transform pathfinding = GameObject.Find("Pathfinding").transform;
        waypoints = new Transform[pathfinding.childCount];
        int index = 0;
        foreach(Transform waypoint in pathfinding)
        {
            waypoints[index] = waypoint;
            index++;
        }
    }


    public void Die()
    {
        GameObject.Find("Player").GetComponent<PlayerManager>().AddSouls(1);
        Destroy(gameObject);
    }
}
