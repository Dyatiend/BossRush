using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace GameControllers
{
    public static class CharacterManager
    {
        public struct CharacterData
        {
            public string charName;
            public string roomName;
            public GameObject playerPrefab;
            public GameObject bossPrefab;

            public CharacterData(string charName, string roomName, string playerPrefabPath, string bossPrefabPath)
            {
                this.charName = charName;
                this.roomName = roomName;
                this.playerPrefab = PrefabUtility.LoadPrefabContents(playerPrefabPath);
                this.bossPrefab = PrefabUtility.LoadPrefabContents(bossPrefabPath);
            }
        }

        public static List<CharacterData> characters = new List<CharacterData>()
        {
            new CharacterData("VoidPresence", "VoidPresenceScene", 
                "Assets/VoidPresence/Prefabs/VoidPresencePlayerFinal.prefab", "Assets/VoidPresence/Prefabs/VoidPresenceBoss.prefab"),
            new CharacterData("Peepob", "PeepobScene", 
                "Assets/Peepob/Prefabs/PeepobPlayerFinal.prefab", "Assets/Peepob/Prefabs/Peepob_Boss.prefab"),
            new CharacterData("Watts", "WattsScene", 
                "Assets/Watts/WattsPlayer.prefab", "Assets/Watts/WattsBoss.prefab"),
            new CharacterData("Golem", "Golem",
                "Assets/Golem/Assets/Prefabs/GolemPlayer_.prefab", "Assets/Golem/Assets/Prefabs/GolemBoss_.prefab")
        };

        public static CharacterData getByCharName(string charName)
        {
            foreach (CharacterData character in characters)
            {
                if (character.charName == charName)
                {
                    return character;
                }
            }
            
            throw new ArgumentException("Unknown character name: " + charName);
        }

        public static CharacterData getByRoomName(string roomName)
        {
            foreach (CharacterData character in characters)
            {
                if (character.roomName == roomName)
                {
                    return character;
                }
            }
            
            throw new ArgumentException("Unknown room name: " + roomName);
        }
    }
}