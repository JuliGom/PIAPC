using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.U2D;
using static UnityEngine.GraphicsBuffer;

public class EnemyMovement : MonoBehaviour
{
    public float distanceBetween;
    public float distanceTeammate;
    public float movementSpeed;
    public float attackDelay;
    public Transform[] movementPoints;
    public float minDistance;
    private int randomNumber;
    private SpriteRenderer spriteRenderer;
    public bool isAttacking = false;
    public GameObject Bullet;
    private float attackDelaySaver;


    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Car").GetComponent<pointsManager>().levelAttempts < 5 && SceneManager.GetActiveScene().name == "Gameplay2")
        {
            movementSpeed = Random.Range(1f, 2f);
            attackDelay = Random.Range(1f, 1.5f);
            attackDelaySaver = attackDelay;

        }
        else
        {
            movementSpeed = 0.5f;
            attackDelay = 3f;
            attackDelaySaver = attackDelay;
        }

        randomNumber = Random.Range(0, movementPoints.Length);
        spriteRenderer = GetComponent<SpriteRenderer>();
        TurnSprite();
    }

    // Update is called once per frame
    void Update()
    {
        distanceBetween = Vector2.Distance(GameObject.Find("Player").transform.position, transform.position);
        distanceTeammate = Vector2.Distance(GameObject.FindGameObjectWithTag("Enemy").transform.position, transform.position);

        if (distanceBetween < 3f || distanceTeammate < 3f && GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyMovement>().isAttacking == true)
        {
            AttackMode();
        }
        else
        {
            PoliceMode();
        }
    }

    private void AttackMode()
    {
        isAttacking = true;
        transform.position = Vector2.MoveTowards(transform.position, GameObject.Find("Player").transform.position, movementSpeed * Time.deltaTime);
        Shooting();
    }

    private void Shooting()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        attackDelay -= Time.deltaTime;
        if (attackDelay < 0)
        {
            Instantiate(Bullet, transform.position, transform.rotation);
            attackDelay = attackDelaySaver;
        }
    }

    private void PoliceMode()
    {
        isAttacking = false;
        GetComponent<SpriteRenderer>().color = Color.white;
        transform.position = Vector2.MoveTowards(transform.position, movementPoints[randomNumber].position, movementSpeed * Time.deltaTime);
        if (Vector2.Distance(transform.position, movementPoints[randomNumber].position) < minDistance)
        {
            randomNumber = Random.Range(0, movementPoints.Length);
            TurnSprite();
        }
    }


    private void TurnSprite()
    {
        if (transform.position.x < movementPoints[randomNumber].position.x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }
}
