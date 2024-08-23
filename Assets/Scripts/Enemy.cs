using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int damage = 5;
    [SerializeField]
    private float speed = 1.5f;

    [SerializeField]
    public EnemyData data;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        SetEnemyValues();
    }

    // Update is called once per frame
    void Update()
    {
        Swarm();
    }

    private void SetEnemyValues()
    {
        GetComponent<Base_Health>().SetHealth(data.hp, data.hp);
        damage = data.damage;
        speed = data.speed;
    }

    private void Swarm()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Bullet"))
        {
                this.GetComponent<Base_Health>().Damage(5); // in loc de 5 pun player damage
                Destroy(collider.gameObject);
        }

        if (collider.CompareTag("Player"))
        {
            if (collider.GetComponent<Player_Health>() != null)
            {
                collider.GetComponent<Player_Health>().Damage(damage);
                this.GetComponent<Base_Health>().Damage(5); 
            }
        }
    }
}
