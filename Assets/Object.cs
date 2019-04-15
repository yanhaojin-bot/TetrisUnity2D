using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    private Transform _transform;
    public float speed = -2.0f;
    int index = 0;
    int timer = 0;
    private Vector2 moveVector;

    public const int MAX_ROWS = 5;
    public const int MAX_COLUMNS = 5;

    // Start is called before the first frame update
    void Start()
    {
        //time = Time.time;
        _transform = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // control movement of object
        if (timer == 120 || index ==1)
        {
            index = 1;
            movement();
        }

        if (GameManager.isPause == 0)
        {
            timer++;
        }
    }

    private void movement()
    {
        if (isValidMapPosition(_transform.position))
        {
            _transform.position += new Vector3(0, speed * Time.deltaTime,0);
        }
        else
        {
            Vector2 pos = Tool.roundVec2(_transform.position);
            _transform.position = pos;
            PlaceObject(this._transform);
        }
    }

    // whether object is valid in the current map position 
    public bool isValidMapPosition(Vector2 v)
    {
        Vector2 pos = Tool.roundVec2(v);

        if (IsInsideMap(pos) == true)
        {

            if (Model.map[(int)pos.x, (int)pos.y -1] != null)
            {
                return false;
            }
                return true;
        }

        if (IsInsidePlayFlowArea(pos) == true)
        {
            return true;
        }
        return false;

    }

    // whether object is valid in the storage area
    private bool IsInsideMap(Vector2 pos)
    {
        return pos.x >= 0 && pos.x < MAX_COLUMNS && pos.y > 0 && pos.y <= MAX_ROWS + 1;
    }

    // whether object is valid in the play and flow area
    private bool IsInsidePlayFlowArea(Vector2 pos)
    {
        return pos.x >= 0 && pos.x < MAX_COLUMNS && pos.y >= MAX_ROWS ;
    }

    // place the object after falling
    public void PlaceObject(Transform t)
    {
        Vector2 pos = Tool.roundVec2(t.position);
        Model.map[(int)pos.x, (int)pos.y] = t;
        Model.checkMap();
        Model.checkWinOrLose();
    }



}
