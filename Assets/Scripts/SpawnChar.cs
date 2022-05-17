using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnChar : MonoBehaviour
{
    private void Awake() {
        Instantiate(PlayerManager.Prefab, GameObject.FindWithTag("Respawn").transform.position+new Vector3(-4.5f,0.3f,8.4f), GameObject.FindWithTag("Respawn").transform.rotation);
    }
}
