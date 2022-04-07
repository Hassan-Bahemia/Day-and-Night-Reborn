using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PlayerMovement : MonoBehaviour
{
    [Header("Private")] 
    [SerializeField] private CharacterController m_playerController;
    [SerializeField] private PlayerStats m_playerStats;
    [SerializeField] private Vector3 m_playerVelocity;
    [SerializeField] private bool m_isGrounded;
    [SerializeField] private bool m_isSprinting;
    [SerializeField] private bool m_isCrouching;
    [SerializeField] private bool m_isJumping;

    [Header("Public")] 
    public float m_speed;
    public float m_normalSpeed;
    public float m_gravity;
    public float m_jumpHeight;
    public float m_sprintMultiplier;
    public float m_crouchingMultiplier;
    public float m_crouchingHeight;
    public float m_standingHeight = 2f;

    // Start is called before the first frame update
    void Start()
    {
        m_playerController = GetComponent<CharacterController>();
        m_playerStats = GetComponent<PlayerStats>();
        m_speed = m_normalSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        m_isGrounded = m_playerController.isGrounded;
        if (!m_isGrounded && !m_isJumping)
        {
            SlopeCheck();
        }

        if (!m_isJumping || !m_isSprinting)
        {
            if (m_playerStats.m_stamina < 100)
            {
                m_playerStats.m_staminaCooldown -= Time.deltaTime;
                if (m_playerStats.m_staminaCooldown <= 0)
                {
                    m_playerStats.GiveStamina(5 * Time.deltaTime * 2f);
                    if (m_playerStats.m_stamina > 100)
                    {
                        m_playerStats.m_stamina = m_playerStats.m_maxStamina;
                    }
                }
            }
        }
        if (m_playerStats.m_stamina >= 100)
        {
            m_playerStats.m_staminaCooldown = 15;
        }
    }

    //Receive input from our Player Input Manager and apply it to the character controller.
    public void ProcessMovement(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        m_playerController.Move(transform.TransformDirection(moveDirection) * m_speed * Time.deltaTime);
        m_playerVelocity.y += m_gravity * Time.deltaTime;
        if (m_isGrounded && m_playerVelocity.y <= 0) {
            m_playerVelocity.y = -2f;
            m_isJumping = false;
            m_isGrounded = true;
        }
        m_playerController.Move(m_playerVelocity * Time.deltaTime);
        if (m_isSprinting && m_isGrounded && m_playerStats.m_stamina > 0) {
            m_playerController.Move(transform.TransformDirection(moveDirection) * m_speed * m_sprintMultiplier * Time.deltaTime);
            if (m_isSprinting) { 
                m_playerStats.TakeStamina(1 * Time.deltaTime * 2f);
            }
        }
        if (m_isCrouching && m_isGrounded) {
            m_playerController.Move(transform.TransformDirection(moveDirection) * m_speed * m_crouchingMultiplier * Time.deltaTime);
        }
    }

    public void Jump()
    {
        if (m_isGrounded && !m_isJumping && m_playerStats.m_stamina > 0)
        {
            m_isJumping = true;
            m_isGrounded = false;
            m_playerVelocity.y = Mathf.Sqrt(m_jumpHeight * -3.0f * m_gravity);
            m_playerStats.TakeStamina(10);
        }
    }

    public void ProcessSprint()
    {
        m_isSprinting = true;
        m_speed *= m_sprintMultiplier;
    }

    public void FinishSprint()
    {
        m_isSprinting = false;
        m_speed = m_normalSpeed;
    }

    public void ProcessCrouching()
    {
        m_isCrouching = true;
        m_playerController.height = m_crouchingHeight;
        m_playerController.center = new Vector3(0, 0.4f, 0);
        m_speed *= m_crouchingMultiplier;
    }

    public void FinishCrouching()
    {
        m_isCrouching = false;
        m_playerController.height = m_standingHeight;
        m_playerController.center = new Vector3(0, 0, 0);
        m_speed = m_normalSpeed;
    }

    private void SlopeCheck()
    {
        m_playerController.Move(-transform.up);
    }
}
