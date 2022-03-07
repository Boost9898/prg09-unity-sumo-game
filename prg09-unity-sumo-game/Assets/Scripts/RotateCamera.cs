using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    [SerializeField]// makes private field editable in inspector
    private float rotationSpeed = 25;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
        // deltatime = amount of secs, realtime shizzle

        transform.position = new Vector3(player.position.x, player.position.y, player.position.z);
    }
}