using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Slider HealthUIBoss;
    public Slider HealthUIPlayer;

    public GameObject Player;

    private Health healthPlayer;
    private Health healthBoss;

    // Start is called before the first frame update
    void Start()
    {
        healthPlayer = Player.GetComponent<Health>();
        healthBoss = GameObject.FindGameObjectsWithTag("Boss")[0].GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        HealthUIBoss.value = healthBoss.healthPoints;
        HealthUIPlayer.value = healthPlayer.healthPoints;
    }
}
