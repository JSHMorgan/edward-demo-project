using System;
using UnityEngine;

public class FireballController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player")) return;
        Destroy(gameObject);
    }
}
