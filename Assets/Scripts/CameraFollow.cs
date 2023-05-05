using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    public Vector2 limitMin;
    public Vector2 limitMax;
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }
    void Update()
    {
        Follow();
    }

    private void LateUpdate()
    {
        Vector3 pos = player.position;

        pos.x = Mathf.Clamp(pos.x, limitMin.x, limitMax.x);
        pos.y = Mathf.Clamp(pos.y, limitMin.y, limitMax.y);
    }
    void Follow()
    {
        if (player)
        {
            transform.position = new Vector3(
                player.position.x,
                player.position.y,
                transform.position.z
                );
        }
    }
}
