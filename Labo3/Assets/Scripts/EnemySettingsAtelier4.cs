using UnityEngine;

public class EnemySettingsAtelier4 : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        PlayerControlsAtelier4 player = collision.GetComponent<PlayerControlsAtelier4>();
        if (player != null)
        {
            player.m_playerAgent.stoppingDistance 
        }
    }
}
