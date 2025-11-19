using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControlsAtelier1 : MonoBehaviour
{
    [SerializeField] InputActionAsset m_inputActions;
    private InputAction m_moveAction;
	private InputAction m_jumpAction;

	[SerializeField] private float m_playerSpeed;
    [SerializeField] private float m_playerJumpForce;
    private bool m_isOnGround = true;
    [SerializeField] private float m_enemyHeight;

    private Rigidbody m_playerRigidbody;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_moveAction = m_inputActions.FindAction("Move");
		m_jumpAction = m_inputActions.FindAction("Jump");
		m_playerRigidbody = GetComponent<Rigidbody>();
        RaycastHit raycastHitInfo;
		if (Physics.Raycast(transform.position, Vector3.down, out raycastHitInfo, m_enemyHeight))
        {
            Debug.Log("Player is dead");
        }
        else
        {
            Debug.Log("Enemy is dead");
        }
	    
	}

    // Update is called once per frame
    void Update()
    {
        Moving();
        Jumping();
        Debug.DrawRay(transform.position, Vector3.down, Color.red);
    }
    private void Moving()
    {
		Vector3 moveAmt = m_moveAction.ReadValue<Vector2>();
        Vector3 calculatedVelocity = m_playerRigidbody.linearVelocity;
        calculatedVelocity.x = moveAmt.x * m_playerSpeed;
		calculatedVelocity.z = moveAmt.y * m_playerSpeed;
		m_playerRigidbody.linearVelocity = calculatedVelocity;
	}
    private void Jumping()
    {
		bool pressedSpaceButton = m_jumpAction.WasPressedThisFrame();
		if (pressedSpaceButton && m_isOnGround)
		{
			m_playerRigidbody.AddForce(Vector3.up * m_playerJumpForce, ForceMode.Impulse);
			m_isOnGround = false;
		}
	}
	private void OnCollisionEnter(Collision collision)
	{
        m_isOnGround = true;
	}
}
