using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTestController : MonoBehaviour
{
   [SerializeField] private float _playerSpeed;
   [SerializeField] private Rigidbody _rb;

   private void Start()
   {
      _rb = GetComponent<Rigidbody>();
   }

   private void FixedUpdate()
   {
      float moveHorizontal = Input.GetAxis("Horizontal");
      float moveVertical = Input.GetAxis("Vertical");
      
      Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
      _rb.AddForce(movement * _playerSpeed);
   }
}