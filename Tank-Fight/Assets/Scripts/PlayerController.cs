using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float moveSpeed;
    [SerializeField] float rotateSpeed;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
    }
    void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        var moveDir = new Vector3(vertical, 0, -horizontal);
        rb.velocity = moveDir;
        RotateToMoveDirection(moveDir);
    }
    void RotateToMoveDirection(Vector3 dir)
    {
        dir.Normalize();
        if (dir == Vector3.zero) return;
        Quaternion rotateTo = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotateTo, rotateSpeed*Time.deltaTime);
    }
}
