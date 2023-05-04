using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float duration = 5f;
    public float speedBoost = 2f;
    public float bulletMultiplier = 2f;
    private Shooting shooting;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerCon player = other.GetComponent<PlayerCon>();
            player.StartCoroutine(PowerUpEffect(player));
            
            Destroy(gameObject);
        }
    }

    IEnumerator PowerUpEffect(PlayerCon player)
    {
        float originalSpeed = player.moveSpeed;
        player.moveSpeed *= speedBoost;
        
        if(player.moveSpeed > 10f)
        {
            player.moveSpeed = 5f;
        }

        shooting.bulletDamage *= bulletMultiplier;

        yield return new WaitForSeconds(duration);

        player.moveSpeed = originalSpeed;
        shooting.bulletDamage /= bulletMultiplier;
    }
}