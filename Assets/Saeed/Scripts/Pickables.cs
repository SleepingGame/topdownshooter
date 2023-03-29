using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickables : MonoBehaviour
{
    public PlayerControls player;
    public string itemEffect;
    public float itemDuration = 10f; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {

                switch (itemEffect)
                {
                    case "FireRateReducce":
                        // player.ReduceFireRate();
                        break;
                    case "SpeedBoost":
                        // player.SpeedBoost();
                        break;
                }


                StartCoroutine(RemoveItemEffect(player));

                // Destroy the pickable object
                Destroy(gameObject);
            }
        }
    }

    IEnumerator RemoveItemEffect(PlayerControls player)
    {
        yield return new WaitForSeconds(itemDuration);

        switch (itemEffect)
        {
            case "FireRateReduction":
                //  player.RestoreFireRate();
                break;
            case "SpeedBoost":
                //  player.RestoreSpeed();
                break;
        }
    }
}
