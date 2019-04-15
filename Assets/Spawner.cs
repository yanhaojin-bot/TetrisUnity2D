using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour

{
    public GameObject[] groups;
    float time = 0.0f;
    int next;
    int timer = 134;

    // Start is called before the first frame update
    void Start()
    {
        next = Random.Range(0, 4);
        time = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

        if (timer == 135)
        {
            next = spawnNext(next);
            time = Time.time;
            timer = 0;
        }

        if (GameManager.isPause == 0)
        {
            timer++;
        }

    }

    //Generate next object
    public int spawnNext(int index)
    {
            // Spawn Group at current Position
            Instantiate(groups[index], transform.position, Quaternion.identity);

            next = index;
            while (next == index)
            {
                // Random Index
                next = Random.Range(0, 4);
            }
            return next;
    }
}
