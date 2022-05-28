using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GameControllers
{
    public class CharacterSelectControls : MonoBehaviour
    {
        public GameObject button;

        private void Start() {
            foreach (CharacterManager.CharacterData character in CharacterManager.characters)
            {
                GameObject newButton = Instantiate(button, transform, true);
                newButton.GetComponent<Button>().onClick.AddListener(delegate { playerChosen(character.charName); });
                newButton.GetComponentInChildren<Text>().text = character.charName;
            }
        }

        public void playerChosen(string charName)
        {
            playerCharacter = CharacterManager.getByCharName(charName);
            // Instantiate(playerCharacter.playerPrefab);
            // Instantiate(playerCharacter.bossPrefab);
            RoomQueue.initAndLoad(charName);
        }

        public static CharacterManager.CharacterData playerCharacter;
    }
}