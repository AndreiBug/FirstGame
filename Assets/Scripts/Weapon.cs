using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public static Weapon instance;

    private Camera mainCam;
    private Vector3 mousePos;
    public GameObject bullet;
    public Transform bulletTransform;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;

    [SerializeField]
    private GameObject[] ammo;
    public int ammoAmount = 20;

    private void Awake()
    {
        instance = this;
    }

    public int getAmmo()
    {
        return ammoAmount;
    }

    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        ammoAmount = 20;
        for (int i = 0; i <= ammoAmount - 1; i++)
        {
            ammo[i].gameObject.SetActive(true);
        }
        
    }

    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ / 360); // 360 ca sa fie punct fix cand trage

        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }
        if (Input.GetMouseButton(0) && canFire && ammoAmount > 0)
        {
            canFire = false;
            var spawnedBullet = Instantiate(bullet, bulletTransform.position, Quaternion.identity);
            ammoAmount -= 1;
            ammo[ammoAmount].gameObject.SetActive(false);
        }
    }

    public void reload()
    {
        ammoAmount = 20;
        for (int i = 0; i <= ammoAmount - 1; i++)
        {
            ammo[i].gameObject.SetActive(true);
        }
    }
}
