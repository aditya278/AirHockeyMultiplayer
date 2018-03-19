using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PugMovement : MonoBehaviour {


    Rigidbody2D rb;
    public Transform startingPosition;

    public Transform BoundaryHolder;

    Boundary playerBoundary;

    public Collider2D PlayerCollider { get; private set; }

    public PlayerController Controller;

    public int? LockedFingerID { get; set; }

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //startingPosition = rb.position;
        PlayerCollider = GetComponent<Collider2D>();

        playerBoundary = new Boundary(BoundaryHolder.GetChild(0).position.y,
                                      BoundaryHolder.GetChild(1).position.y,
                                      BoundaryHolder.GetChild(2).position.x,
                                      BoundaryHolder.GetChild(3).position.x);

    }

    private void OnEnable()
    {
        Debug.Log("Enabled!");
        PlayerController.Players.Add(this);
    }
    private void OnDisable()
    {

        Debug.Log("Disabled!");
        PlayerController.Players.Remove(this);
    }

    public void MoveToPosition(Vector2 position)
    {
        Vector2 clampedMousePos = new Vector2(Mathf.Clamp(position.x, playerBoundary.Left,
                                                  playerBoundary.Right),
                                      Mathf.Clamp(position.y, playerBoundary.Down,
                                                  playerBoundary.Up));
        rb.MovePosition(clampedMousePos);
    }

    public void ResetPosition()
    {
        rb.position = startingPosition.position;
    }
}
