using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RoomManager
{
    private static List<int> rooms;

    private static int WINNER_SCENE = 4;

    public static void SetupRooms() {
        int[] loadRooms = { 1, 2, 3 };
        rooms = new List<int>(loadRooms);
    }

    public static void DeleteRoom(int room) {
        rooms.Remove(room);
    }

    public static int GetRandomRoom() {
        var random = new System.Random();
        int index = random.Next(rooms.Count);
        if(rooms.Count == 0) {
            return WINNER_SCENE;
        }
        int room = rooms[index];
        DeleteRoom(room);
        return room;
    }
}
