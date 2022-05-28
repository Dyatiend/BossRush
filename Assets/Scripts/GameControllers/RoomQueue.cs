using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;

namespace GameControllers
{
    public static class RoomQueue
    {
        private static List<string> rooms = new List<string>();
        private static int currentRoom = 0;

        public static void initAndLoad(string charName)
        {
            rooms.Add(CharacterManager.getByCharName(charName).roomName);
            Random r = new Random();
            foreach (int i in Enumerable.Range(0, CharacterManager.characters.Count).OrderBy(x => r.Next()))
            {
                CharacterManager.CharacterData c = CharacterManager.characters[i];
                if (c.charName != charName)
                {
                    rooms.Add(c.roomName);
                }
            }

            SceneManager.LoadScene(rooms[currentRoom]);
        }

        private static string WINNER_SCENE = "WinnerScene";

        public static void loadNextRoom()
        {
            currentRoom++;
            if (currentRoom < rooms.Count)
            {
                SceneManager.LoadScene(rooms[currentRoom]);
            }
            else
            {
                SceneManager.LoadScene(WINNER_SCENE);
            }
        }

        public static void reset()
        {
            currentRoom = 0;
            rooms = new List<string>();
        }
    }
}