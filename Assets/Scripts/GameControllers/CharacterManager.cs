﻿using System;
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
                "Assets/VoidPresence/Prefabs/Player2.prefab", "Assets/VoidPresence/Prefabs/VoidPresenceBoss.prefab"),
            new CharacterData("Peepob", "PeepobScene", 
                "Assets/Peepob/Prefabs/Player.prefab", "Assets/Peepob/Prefabs/Peepob_Boss.prefab")
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