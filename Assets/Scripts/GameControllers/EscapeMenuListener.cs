using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeMenuListener : MonoBehaviour
{
    public GameObject menuPrefab;
    private GameObject menu;

    void Start() {
        
        menu = Instantiate(menuPrefab);
        menu.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            menu.SetActive(!menu.activeSelf);
        }
    }
}
