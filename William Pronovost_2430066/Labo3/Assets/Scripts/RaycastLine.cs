using UnityEngine;

public class RaycastLine : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
		RaycastHit[] hits = Physics.RaycastAll(transform.position, Vector3.right, 25.0f);
		foreach (RaycastHit hit in hits)
		{
			hit.collider.gameObject.GetComponent<EnemySettings>().GreyEnemyKill();
		}
	}
}
