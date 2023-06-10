using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneySpawner : MonoBehaviour
{
    public GameObject[] moneyBags = new GameObject[5];

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < moneyBags.Length; i++)
        {
            Instantiate(moneyBags[i], new Vector3(Random.Range(-5.75f, 5.75f), Random.Range(-9f, 6f), transform.position.z), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
