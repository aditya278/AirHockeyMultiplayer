using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PugMovement : MonoBehaviour {


    bool wasJustClicked = true;
    bool canMove;
    Vector2 playerSize;
    public Rigidbody2D rb;

    public Transform BoundaryPoints;

    Boundary PlayerBoundary;


    // Use this for initialization
    void Start()
    {
        playerSize = gameObject.GetComponent<SpriteRenderer>().bounds.extents;
        rb = GetComponent<Rigidbody2D>();

        PlayerBoundary = new Boundary(BoundaryPoints.GetChild(0).position.y,
                                      BoundaryPoints.GetChild(1).position.y,
                                      BoundaryPoints.GetChild(2).position.x,
                                      BoundaryPoints.GetChild(3).position.x);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (wasJustClicked)
            {
                wasJustClicked = false;

                if ((mousePos.x >= transform.position.x && mousePos.x < transform.position.x + playerSize.x ||
                mousePos.x <= transform.position.x && mousePos.x > transform.position.x - playerSize.x) &&
                (mousePos.y >= transform.position.y && mousePos.y < transform.position.y + playerSize.y ||
                mousePos.y <= transform.position.y && mousePos.y > transform.position.y - playerSize.y))
                {
                    canMove = true;
                }
                else
                {
                    canMove = false;
                }
            }

            if (canMove)
            {
                //transform.position = mousePos;

                Vector2 clampedMousePos = new Vector2(Mathf.Clamp(mousePos.x, PlayerBoundary.Left, PlayerBoundary.Right), Mathf.Clamp(mousePos.y, PlayerBoundary.Down, PlayerBoundary.Up));

                rb.MovePosition(clampedMousePos);
            }
        }
        else
        {
            wasJustClicked = true;
        }
    }
}
