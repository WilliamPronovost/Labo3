using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControlsAtelier1 : MonoBehaviour
{
	[SerializeField] LayerMask m_enemyLayer;
    [SerializeField] InputActionAsset m_inputActions;
    private InputAction m_moveAction;
	private InputAction m_jumpAction;

	[SerializeField] private float m_playerSpeed;
    [SerializeField] private float m_playerJumpForce;
    private bool m_isOnGround = true;

    private Rigidbody m_playerRigidbody;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_moveAction = m_inputActions.FindAction("Move");
		m_jumpAction = m_inputActions.FindAction("Jump");
		m_playerRigidbody = GetComponent<Rigidbody>();
	    
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
		if (pressedSpaceButton)
		{
			RaycastHit raycastHitInfo;
			if (Physics.Raycast(transform.position, Vector3.down, out raycastHitInfo, 1.01f))
			{
				m_playerRigidbody.AddForce(Vector3.up * m_playerJumpForce, ForceMode.Impulse);
				
			}
		}
	}
	private void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
		{
			if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit raycastHitInfo, 1.01f, m_enemyLayer))
			{
				raycastHitInfo.collider.gameObject.GetComponent<EnemySettingsAtelier1>().Kill();
			}
			else
			{
				Destroy(gameObject);
			}
		}
	}
}
