using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class movePLEASE : MonoBehaviour
{
    Rigidbody myRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = this.GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update () {
        mouseLook();
        if(Input.GetKey(KeyCode.W))
        { myRigidbody.velocity += transform.forward; }
        if(Input.GetKey(KeyCode.A))
        { myRigidbody.velocity += transform.right * -1; }
        if(Input.GetKey(KeyCode.S))
        { myRigidbody.velocity += transform.forward * -1; }
        if(Input.GetKey(KeyCode.D))
        { myRigidbody.velocity += transform.right; }

    }

    void mouseLook () {
        float x = Input.GetAxis("Mouse X") * Time.deltaTime * 75f;

        transform.Rotate(Vector3.up * x);
    }
}
