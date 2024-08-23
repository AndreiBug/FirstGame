using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRegen : MonoBehaviour
{
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    [SerializeField] HealthBar healthbar;
    [SerializeField] Player_Health hp;
    [SerializeField] int healPoints = 10;
    private bool IsNextWave = false;
    [SerializeField] Animator animator;

    private void Update()
    {
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("WaveComplete")  && IsNextWave == false)
        {
            IsNextWave = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsNextWave == true) 
        {
            Player pl = collision.gameObject.GetComponentInChildren<Player>();
            if (pl)
            {
                hp.Heal(healPoints);
                healthbar.SetHealth(hp.get_health());
                IsNextWave = false;
            }
        }
    }
}
