using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] MainMenu menu;
    [SerializeField] Weapon weapon;
    [SerializeField] Player player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menu.gameObject.SetActive(!menu.gameObject.activeSelf);

            if (menu.gameObject.activeInHierarchy == true) { 
                Time.timeScale = 0; 
                weapon.canFire = false;
            }
            else
            {
                Time.timeScale = 1.0f;
                weapon.canFire = true;
            }
        }
    }
}
