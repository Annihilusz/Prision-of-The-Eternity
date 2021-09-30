using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //public Transform PlayerTransform;
    public GameObject player;

    public Vector3 _cameraOffset;

    [Range(0.01f, 1.0f)]
    public float smoothFactor = 0.5f;

    public bool lookAtPlayer = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        // _cameraOffset = transform.position - PlayerTransform.position;
        _cameraOffset = transform.position - player.transform.position;
        

    }

    // Update is called once per frame
    void LateUpdate()
    {
        //print(player.transform.position);
        //_cameraOffset = transform.position - PlayerTransform.position;
        Vector3 newPos = player.transform.position + _cameraOffset;

        transform.position = Vector3.Slerp(transform.position, newPos, smoothFactor);

        if (lookAtPlayer)
        {
            transform.LookAt(player.transform);
        }
        if (player.GetComponent<PlayerCtrl>().currentHealth < 1)
        {
            _cameraOffset = transform.position - player.transform.position;
        }
    }
}


