using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCamera : MonoBehaviour
{
    public GameObject Player;
    public float heightCamera = 7.0f;
    public float depthCamera = 8.0f;
    public float angleCamera = 40.0f;
    private Vector3 cameraDistance;



    /*  Start is called before the first frame update
    *   @version 1.0
    */
    void Start()
    {
        cameraDistance = new Vector3(0, heightCamera, -depthCamera);

        Quaternion test = Quaternion.Euler(40, 0, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, test, 1);
    }



    /*  Update is called once per frame
    *   @version 1.0
    */
    void Update()
    {
        transform.position = Player.transform.position + cameraDistance;
    }
}
