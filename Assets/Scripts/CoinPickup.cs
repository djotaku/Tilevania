using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{

    [SerializeField] AudioClip coinPickuUpSFX;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioSource.PlayClipAtPoint(coinPickuUpSFX, Camera.main.transform.position);
        Destroy(gameObject);
    }
}
