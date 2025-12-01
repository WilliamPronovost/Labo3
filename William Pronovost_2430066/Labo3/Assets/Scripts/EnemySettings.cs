using UnityEngine;

public class EnemySettings : MonoBehaviour
{
	public void Kill()
	{
		Destroy(gameObject);
	}
	public void GreyEnemyKill()
	{
		if (gameObject.CompareTag("Enemy"))
		{
			Destroy(gameObject);
		}
	}
}
