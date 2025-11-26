using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerControlsAtelier4 : MonoBehaviour
{
    private NavMeshAgent m_playerAgent;

    [SerializeField] private InputActionAsset m_inputActions;
    private InputAction m_moveAction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_playerAgent = GetComponent<NavMeshAgent>();
        m_moveAction = m_inputActions.FindAction("Move");
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
            if(Physics.Raycast(rayFromCamera, out RaycastHit info))
            {
                m_playerAgent.SetDestination(info.point);
            }  
        }
    }
    private void PlayerDistanceFromEnemy()
    {
        RaycastHit raycastHitInfo;
        if (Physics.Raycast(transform.position, transform.position, out raycastHitInfo, m_playerAgent.stoppingDistance))
        {
           
        }
        Debug.DrawRay(transform.position, transform.position, Color.red);
    }
}
