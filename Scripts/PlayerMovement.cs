using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 speed = new Vector2(5, 5);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float iX = Input.GetAxis("Horizontal");
        float iY = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(speed.x * iX, speed.y * iY, 0);
        movement *= Time.deltaTime;
        transform.Translate(movement);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -5.75f, 5.75f), Mathf.Clamp(transform.position.y, -9f, 9f), transform.position.z);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            GameObject.FindGameObjectWithTag("Car").GetComponent<pointsManager>().levelAttempts += 1;
            SceneManager.LoadScene("Lose");
        }
        else
        {
            if (collision.gameObject.tag == "Car" && GameObject.FindGameObjectWithTag("Car").GetComponent<pointsManager>().points == 5)
            {
                SceneManager.LoadScene("Winner");
            }
            else
            {
                if (collision.gameObject.tag == "Money")
                {
                    GameObject.FindGameObjectWithTag("Car").GetComponent<pointsManager>().points += 1;
                    Destroy(collision.gameObject);                                                                     
                }
            }
        }
    }
}
