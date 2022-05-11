using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnChar : MonoBehaviour
{
    private void Awake() {
        Instantiate(PlayerManager.Prefab, GameObject.FindWithTag("Respawn").transform.position+new Vector3(-4,1.3f,28.4f), GameObject.FindWithTag("Respawn").transform.rotation);
    }
}
