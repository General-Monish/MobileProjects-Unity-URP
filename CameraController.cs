using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    Vector3 distanceBetweenCameraAndPlayer;
    // Start is called before the first frame update
    void Start()
    {
        distanceBetweenCameraAndPlayer = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    private void LateUpdate()
    {
        transform.position=player.transform.position+distanceBetweenCameraAndPlayer;
    }


}
