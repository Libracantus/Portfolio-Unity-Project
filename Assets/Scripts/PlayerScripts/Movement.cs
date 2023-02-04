using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
public class Movement : MonoBehaviour
{
    [SerializeField]
    private float speed = 10.0f;
    [SerializeField]
    private bool isGrounded = true;
    Collider Ground = new();
    private Rigidbody Rigidbody;
    private float JumpSpeed = 10.0f;
    [SerializeField]
    private Transform GroundCheckOrigin;
    [SerializeField]
    private float GroundCheckRange = 0.1f;
    [SerializeField]
    private LayerMask GroundCheckLayerMask;

    private void Start()
    {
        Ground = GetComponentInChildren<SphereCollider>();
        Rigidbody= GetComponent<Rigidbody>();
    }
    void Update()
    {
        Move();
        CheckGrounded();
    }

    private void CheckGrounded()
    {
        if (Physics.OverlapSphere(GroundCheckOrigin.position,GroundCheckRange,GroundCheckLayerMask).Count()!= 0)
        {
            isGrounded = true;
            Debug.Log("I'm grounded :3");
            Debug.Log(Physics.OverlapSphere(GroundCheckOrigin.position, GroundCheckRange, GroundCheckLayerMask));
        }
        //else
        //{
        //    isGrounded= false;
        //}                
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(GroundCheckOrigin.position, GroundCheckRange);
    }
    //private void OnTriggerEnter(Collision collision)
    //{
    //    //if (collision.collider == Ground)
    //    //{
    //    //    isGrounded = true;
    //    //}
    //    //if (collision.gameObject.CompareTag("Ground"))
    //    //{
    //    //    isGrounded = true;
    //    //}
    //}

    void Move()
    {
        if (Input.GetKey(KeyCode.D))
        {
            Rigidbody.position += Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Rigidbody.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            Rigidbody.position += Vector3.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Rigidbody.position += Vector3.back * speed * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            //Rigidbody.velocity.Set(Rigidbody.velocity.x,Rigidbody.velocity.y + JumpSpeed, Rigidbody.velocity.z);
            Rigidbody.AddForce(new Vector3(0, JumpSpeed, 0), ForceMode.Impulse);
            isGrounded = false;
            Debug.Log("not grounded 3:");
        }
    }


}
