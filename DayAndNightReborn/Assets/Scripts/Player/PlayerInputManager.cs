using System;
using UnityEngine;

namespace Player
{
    public class PlayerInputManager : MonoBehaviour
    {
        [SerializeField] private PlayerControls m_playerControls;
        [SerializeField] private PlayerControls.PlayerMovementActions m_playerMovementActions;
        [SerializeField] private Vector2 m_movementInput;
        [SerializeField] private PlayerMovement m_playerMovement;
        [SerializeField] private PlayerLook m_playerLook;
        
        private void Awake()
        {
            m_playerControls = new PlayerControls();
            m_playerMovementActions = m_playerControls.PlayerMovement;
            
            m_playerMovement = GetComponent<PlayerMovement>();
            m_playerLook = GetComponent<PlayerLook>();
            
            m_playerMovementActions.Jump.performed += ctx => m_playerMovement.Jump();
        }
        
        void FixedUpdate()
        {
            //Tell the Player Movement to move using the value from the movement action
            m_playerMovement.ProcessMovement(m_playerMovementActions.Movement.ReadValue<Vector2>());
        }

        private void LateUpdate()
        {
            //Tell the Player Movement to move using the value from the movement action
            m_playerLook.ProcessLook(m_playerMovementActions.Look.ReadValue<Vector2>());
        }

        private void OnEnable()
        {
            m_playerMovementActions.Enable();
        }

        private void OnDisable()
        {
            m_playerMovementActions.Disable();
        }
    }
}
