using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
   [Header("Public")]
   public Camera m_cam;
   public float m_xSensitivity;
   public float m_ySensitivity;

   [Header("Private")]
   [SerializeField] private float m_xRotation;

   private void Awake()
   {
      m_cam = GetComponentInChildren<Camera>();
   }

   public void ProcessLook(Vector2 input)
   {
      float mouseX = input.x;
      float mouseY = input.y;
      
      //Calculate the camera rotation for looking up/down
      m_xRotation -= (mouseY * Time.deltaTime) * m_ySensitivity;
      m_xRotation = Mathf.Clamp(m_xRotation, -80f, 80f);
      //Apply to camera transform
      m_cam.transform.localRotation = Quaternion.Euler(m_xRotation, 0, 0);
      //Rotate player to make them look left/right
      transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * m_xSensitivity);
   }
   
}
