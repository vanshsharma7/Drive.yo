using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive : MonoBehaviour
{
    [SerializeField] float steerSpeed = 0.1f;
    [SerializeField] float moveSpeed = 10;
    [SerializeField] float SpeedDown = 5;
    [SerializeField] float SpeedUp = 50;

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0,0,-steerAmount);
        transform.Translate(0,moveAmount,0);
    }

    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("You Just Bumped Into Something!");
        moveSpeed=SpeedDown;    
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="SpeedUp"){
            Debug.Log("You Just Speed Up!");
            moveSpeed = SpeedUp;
        }
    }

}
