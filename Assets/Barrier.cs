
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    private Transform _transform;
    public float speed = 3.0f;
    public float a = 10f;

    // Start is called before the first frame update
    void Start()
    {

        _transform = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // when game starts, barrier can be operated by keyboard
        if (GameManager.isPause == 0)
        {
            if (Input.GetKey(KeyCode.UpArrow) && transform.position.y < 6.77)
            {
                _transform.Translate(Vector2.up * speed * Time.deltaTime, Space.Self);
            }
            if (Input.GetKey(KeyCode.DownArrow) && transform.position.y > 5.2)
            {
                _transform.Translate(Vector2.down * speed * Time.deltaTime, Space.Self);
            }
            if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > 0.2)
            {
                _transform.Translate(Vector2.left * speed * Time.deltaTime, Space.Self);
            }
            if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < 3.8)
            {
                _transform.Translate(Vector2.right * speed * Time.deltaTime, Space.Self);
            }
        }
    }

    // detect the collision which happens between the bottom of debris and barrier
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Debris")
        {
            Model.HitNum++;
            Debug.Log("HitNum: " + Model.HitNum);
            Destroy(other.gameObject);
            Model.score = Model.score + 5;
        }

    }
}
