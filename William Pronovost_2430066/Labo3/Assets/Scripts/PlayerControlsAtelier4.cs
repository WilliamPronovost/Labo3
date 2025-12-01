using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerControlsAtelier4 : MonoBehaviour
{
    [SerializeField] private InputActionAsset m_inputFile;
    private InputAction m_moveAction;
    private NavMeshAgent m_playerAgent;
    private Transform m_enemy;
    private float m_elapsed;
    private float m_delay = 5.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_moveAction = m_inputFile.FindAction("Move");
        m_playerAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Moving();
        PlayerDistanceFromEnemy();
    }
    private void Moving()
    {
		if (m_moveAction.WasPressedThisFrame())
		{
			Ray rayFromCamera = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
			if (Physics.Raycast(rayFromCamera, out RaycastHit hitInfo))
			{
				m_playerAgent.SetDestination(hitInfo.point);

			}
		}
	}
    private void PlayerDistanceFromEnemy()
    {
        if(Vector3.Distance(m_playerAgent.transform.position, m_enemy.position) <= m_playerAgent.stoppingDistance)
        {
            m_elapsed += Time.deltaTime;
            if (m_elapsed >= m_delay)
            {

            }
        }
    }
}
