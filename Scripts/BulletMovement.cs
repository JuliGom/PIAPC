using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class BulletMovement : MonoBehaviour
{
    Transform inHead;

    // Start is called before the first frame update
    void Start()
    {
        inHead = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Gameplay")
        {
            transform.position = Vector2.MoveTowards(transform.position, inHead.position, 2f * Time.deltaTime);
            Destroy(gameObject, 2);
        }
        else
        {
            if (SceneManager.GetActiveScene().name == "Gameplay2")
            {
                transform.position = Vector2.MoveTowards(transform.position, inHead.position, 2f * Time.deltaTime);
                Destroy(gameObject, 3);
            }
        }
    }
}
