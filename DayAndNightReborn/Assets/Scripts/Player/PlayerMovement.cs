using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Private")]
    [SerializeField] private CharacterController m_playerController;
    [SerializeField] private Vector3 m_playerVelocity;
    [SerializeField] private bool m_isGrounded;
    
    [Header("Public")]
    public float m_speed;
    public float m_gravity;
    public float m_jumpHeight;
    
    // Start is called before the first frame update
    void Start()
    {
        m_playerController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        m_isGrounded = m_playerController.isGrounded;
    }
    
    //Receive input from our Player Input Manager and apply it to the character controller.
    public void ProcessMovement(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        m_playerController.Move(transform.TransformDirection(moveDirection) * m_speed * Time.deltaTime);
        m_playerVelocity.y += m_gravity * Time.deltaTime;
        if (m_isGrounded && m_playerVelocity.y < 0)
            m_playerVelocity.y = -2f;
        m_playerController.Move(m_playerVelocity * Time.deltaTime);
    }

    public void Jump()
    {
        if (m_isGrounded)
            m_playerVelocity.y = Mathf.Sqrt(m_jumpHeight * -3.0f * m_gravity);
    }
}
