using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnChar : MonoBehaviour
{
    private void Awake() {
        Instantiate(PlayerManager.Prefab, GameObject.FindWithTag("Respawn").transform.position, GameObject.FindWithTag("Respawn").transform.rotation);
    }
}
