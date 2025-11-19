using UnityEngine;

public class EnemySettingsAtelier1 : MonoBehaviour
{
	private void OnTriggerEnter(Collider collision)
	{
		PlayerControlsAtelier1 player = collision.GetComponent<PlayerControlsAtelier1>();
		if (player != null)
		{
			Destroy(gameObject);
		}
	}
}
