using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneDelay : MonoBehaviour
{
    public float sceneDelay = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sceneDelay -= Time.deltaTime;
        if (sceneDelay < 0)
        {
            SceneManager.LoadScene("Gameplay");
        }
    }
}
