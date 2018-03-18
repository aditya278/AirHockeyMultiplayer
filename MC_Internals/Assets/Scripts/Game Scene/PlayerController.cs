using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public List<PugMovement> Players = new List<PugMovement>();

    public GameObject AiPlayer;

    private void Start()
    {
        if (ValueScript.IsMultiplayer)
        {
            AiPlayer.GetComponent<PugMovement>().enabled = true;
            AiPlayer.GetComponent<AIMovementScript>().enabled = false;
        }
        else
        {
            AiPlayer.GetComponent<PugMovement>().enabled = false;
            AiPlayer.GetComponent<AIMovementScript>().enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            Vector2 touchWorldPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
            foreach (var player in Players)
            {
                if (player.LockedFingerID == null)
                {
                    if (Input.GetTouch(i).phase == TouchPhase.Began &&
                        player.PlayerCollider.OverlapPoint(touchWorldPos))
                    {
                        player.LockedFingerID = Input.GetTouch(i).fingerId;
                    }
                }
                else if (player.LockedFingerID == Input.GetTouch(i).fingerId)
                {
                    player.MoveToPosition(touchWorldPos);
                    if (Input.GetTouch(i).phase == TouchPhase.Ended ||
                        Input.GetTouch(i).phase == TouchPhase.Canceled)
                        player.LockedFingerID = null;
                }
            }
        }
    }
}
