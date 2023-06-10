using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class pointsManager : MonoBehaviour
{
    public int points;
    public float levelTimer;
    public int levelAttempts;

    void Awake()
    {
        GameObject[] playerObj = GameObject.FindGameObjectsWithTag("Car");

        if (playerObj.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        levelTimer = levelTimer + Time.deltaTime;

        if (SceneManager.GetActiveScene().name == "Lose" || SceneManager.GetActiveScene().name == "Winner")
        {
            points = 0;
            levelTimer = 0;
        }
    }
}
