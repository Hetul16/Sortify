using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform mainCamera;
    private Vector3 _direction = Vector3.zero;

    public float xSpeed = 0.05f;
    public float ySpeed = 0.05f;
    public float zSpeed = 0.05f;

    float degreesPerSecond = 20;

    public float rotateSpeed = 90.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D)){
        transform.position += new Vector3(xSpeed ,0 ,0);
        }

        if(Input.GetKey(KeyCode.A)){
        transform.position -= new Vector3(xSpeed ,0 ,0);
        }

        if(Input.GetKey(KeyCode.W)){
        transform.position += new Vector3(0 ,ySpeed ,0);
        }

        if(Input.GetKey(KeyCode.S)){
        transform.position -= new Vector3(0 ,ySpeed ,0);
        }

        if(Input.GetKey(KeyCode.Q)){
        transform.position += new Vector3(0 ,0 ,zSpeed);
        }

        if(Input.GetKey(KeyCode.E)){
        transform.position -= new Vector3(0 ,0 ,zSpeed);
        }

        if ( Input.GetMouseButton( 1 ) )
        {
            
            mainCamera.RotateAround( mainCamera.position, Vector3.up, Input.GetAxis( "Mouse X" ) * rotateSpeed * Time.unscaledDeltaTime );
            mainCamera.RotateAround( mainCamera.position, mainCamera.right, -Input.GetAxis( "Mouse Y" ) * rotateSpeed * Time.unscaledDeltaTime );

            _direction = V3RotateAround( _direction, Vector3.up, Input.GetAxis( "Mouse X" ) * rotateSpeed * Time.unscaledDeltaTime );
            _direction = V3RotateAround( _direction, mainCamera.right, -Input.GetAxis( "Mouse Y" ) * rotateSpeed * Time.unscaledDeltaTime );
        }
        //For Rotation
        // if(Input.GetKey(KeyCode.F)){
        //     transform.Rotate(new Vector3(0, degreesPerSecond, 0) * Time.deltaTime);
        // }
    }

     public Vector3 V3RotateAround( Vector3 source, Vector3 axis, float angle )
        {
            var q = Quaternion.AngleAxis( angle, axis ); 
            return q * source; 
        }
}
