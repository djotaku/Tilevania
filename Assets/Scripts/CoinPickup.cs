﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{

    [SerializeField] AudioClip coinPickuUpSFX;
    [SerializeField] int pointsForCoinPickup = 100;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<GameSession>().AddToScore(pointsForCoinPickup);
        AudioSource.PlayClipAtPoint(coinPickuUpSFX, Camera.main.transform.position);
        Destroy(gameObject);
    }
}
