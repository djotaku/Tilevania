using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float runSpeed = 5f;
    Rigidbody2D myRigidboy;

    // Start is called before the first frame update
    void Start()
    {
        myRigidboy = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
    }

    private void Run()
    {
        float controlThrow = Input.GetAxis("Horizontal");  //value is -1 to 1
        Vector2 playerVelocity = new Vector2(controlThrow * runSpeed, myRigidboy.velocity.y);
        myRigidboy.velocity = playerVelocity;
    }
}