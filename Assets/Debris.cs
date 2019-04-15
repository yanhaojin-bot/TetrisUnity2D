using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debris : MonoBehaviour
{
    private Transform _transform;
    public float speed = -2.0f;
    int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        _transform = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("changeIndex", 2);
        if (transform.position.y > -6.5 && index == 1)
        {
            _transform.position += new Vector3(0, speed * Time.deltaTime,0);
        }
    }

    private void changeIndex()
    {
        index = 1;
    }
}
