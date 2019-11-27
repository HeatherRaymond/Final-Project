using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUp : MonoBehaviour
{
    public Text powerUpText;

    private float multiplier = .35f;

    private float duration = 3f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(PickUp(other));
        }
    }

    IEnumerator PickUp(Collider player)
    {


        PlayerController delayWait = player.GetComponent<PlayerController>();
        delayWait.fireRate *= multiplier;
        powerUpText.text = "Bullets Accelerated";
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(duration);

        delayWait.fireRate /= multiplier;
        powerUpText.text = "";
        Destroy(gameObject);

    }
}