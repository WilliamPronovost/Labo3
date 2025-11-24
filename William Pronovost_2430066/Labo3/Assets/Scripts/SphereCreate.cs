
using UnityEngine;
using UnityEngine.InputSystem;

public class SphereCreate : MonoBehaviour
{
    private int m_groundLayer;
    private int m_sphereLayer;
    [SerializeField] Transform m_sphereCollection;
    [SerializeField] InputActionAsset m_inputActions;
    [SerializeField] GameObject m_spherePrefab;
    private InputAction m_shootAction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_shootAction = m_inputActions.FindAction("Shoot");
        m_groundLayer = LayerMask.NameToLayer("Ground");
		m_sphereLayer = LayerMask.NameToLayer("Sphere");
	}

    // Update is called once per frame
    void Update()
    {
        if (m_shootAction.WasPressedThisFrame())
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue()), out RaycastHit info))
            {
                if(info.collider.gameObject.layer == m_groundLayer)
                {
                    CreateSphere(info.point);
                }
                else
                {
                    RandomizeColor(info.collider.gameObject);
                }
            }
        }
    }

	private void RandomizeColor(GameObject sphere)
	{
        MeshRenderer renderer = sphere.GetComponent<MeshRenderer>();
        renderer.material.color = Random.ColorHSV();
	}

	private void CreateSphere(Vector3 position)
    {
        Instantiate(m_spherePrefab, position, Quaternion.identity, m_sphereCollection);
    }
}
