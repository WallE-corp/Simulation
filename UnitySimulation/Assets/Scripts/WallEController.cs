using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallEController : MonoBehaviour
{
    
    public float moveSpeed = 6;
    public float rotateSpeed = 6;

    [HideInInspector]
    public Rigidbody rigidbody;

    Camera viewCamera;

    Vector3 velocity;
    
    [HideInInspector]
    public IInputProvider inputProvider;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        viewCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = viewCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, viewCamera.transform.position.y));
        // transform.LookAt(mousePos + Vector3.up * transform.position.y);
        // velocity = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized * moveSpeed;
        Vector3 moveDir = inputProvider.GetInputState().movementDir;
        //velocity = moveDir * moveSpeed;
        if (moveDir == Vector3.forward) velocity = transform.forward * moveSpeed;
        else if (moveDir == -Vector3.forward) velocity = -transform.forward * moveSpeed;
        else velocity = Vector3.zero;
    }

    private void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + velocity * Time.fixedDeltaTime);
        rigidbody.angularVelocity = inputProvider.GetInputState().rotation * rotateSpeed;
    }
}
