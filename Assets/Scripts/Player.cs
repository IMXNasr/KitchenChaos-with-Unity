using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Player : MonoBehaviour{
    [SerializeField] private float speed = 7;
    private bool isWalking;
    private void Update(){
        Vector2 inputVector = new Vector2(0, 0);
        if(Input.GetKey(KeyCode.UpArrow)){
            inputVector.y = 1;
        }
        if (Input.GetKey(KeyCode.DownArrow)){
            inputVector.y = -1;
        }
        if (Input.GetKey(KeyCode.LeftArrow)){
            inputVector.x = -1;
        }
        if (Input.GetKey(KeyCode.RightArrow)){
            inputVector.x = 1;
        }
        inputVector = inputVector.normalized;
        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);
        transform.position += moveDir * (Time.deltaTime * speed);
        isWalking = moveDir != Vector3.zero;

        float rotateSpeed = 10;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
    }
    public bool IsWalking(){
        return isWalking;
    }
}
