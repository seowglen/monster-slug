using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private float minX = -72f;
    [SerializeField]
    private float maxX = 72f;

    private Transform player;
    private Vector3 tempPos;

    private string PLAYER_TAG = "Player";

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag(PLAYER_TAG).transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!player) return;

        tempPos = transform.position;
        tempPos.x = player.position.x;

        if (tempPos.x < minX) {
            tempPos.x = minX;
        }

        if (tempPos.x > maxX) {
            tempPos.x = maxX;
        }

        transform.position = tempPos;
    }
}
