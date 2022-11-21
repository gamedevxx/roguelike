using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RoomPlacer : MonoBehaviour {
	public Room[] roomPrefabs;
	public BossRoom[] bossRoomPrefabs;
	public Room startingRoom;
	public int n;
	public int levelSize;

	private Room[,] spawnedRooms;

    void Start() {
    	Room start = Instantiate(startingRoom);
    	start.transform.position = new Vector3(0, 0, 0);

        spawnedRooms = new Room[n + 1, n + 1];
        spawnedRooms[n / 2, n / 2] = start;

        for (int i = 0; i < levelSize; ++i) {
        	GenerateRoom(false);
        }

        GenerateRoom(true);

        ConnectRooms();
    }

    private void GenerateRoom(bool isBossRoom = false) {
    	HashSet<Vector2Int> freePlaces = new HashSet<Vector2Int>();

    	for (int x = 0; x < n; ++x) {
    		for (int y = 0; y < n; ++y) {
    			if (spawnedRooms[x, y] != null) {
    				continue;
    			}
    			int cntNeigbours = 0;
    			if (x > 0 && spawnedRooms[x - 1, y] != null) {
    				cntNeigbours++;
    			}
    			if (x < n && spawnedRooms[x + 1, y] != null) {
    				cntNeigbours++;
    			}
    			if (y > 0 && spawnedRooms[x, y - 1] != null) {
    				cntNeigbours++;
    			}
    			if (y < n && spawnedRooms[x, y + 1] != null) {
    				cntNeigbours++;
    			}

    			if (cntNeigbours > 0 && cntNeigbours < 2 && !isBossRoom) {
    				freePlaces.Add(new Vector2Int(x, y));
    			}
    			if (cntNeigbours == 1 && isBossRoom) {
    				freePlaces.Add(new Vector2Int(x, y));
    			}
    		}
    	}

    	Room newRoom;
    	if (!isBossRoom)
    		newRoom = Instantiate(roomPrefabs[Random.Range(0, roomPrefabs.Length)]);
    	else
    		newRoom = Instantiate(bossRoomPrefabs[Random.Range(0, bossRoomPrefabs.Length)]);
    	Vector2Int pos = freePlaces.ToList()[Random.Range(0, freePlaces.Count)];
    	newRoom.transform.position = new Vector3((pos.x - n / 2) * 7, (pos.y - n / 2) * 6, 0);
    	spawnedRooms[pos.x, pos.y] = newRoom;
    }

    private void ConnectRooms() {
    	for (int x = 0; x < n; ++x) {
    		for (int y = 0; y < n; ++y) {
    			if (spawnedRooms[x, y] == null) {
    				continue;
    			}

    			if (x > 0 && spawnedRooms[x - 1, y] != null) {
    				spawnedRooms[x, y].DoorL.SetActive(false);
    				spawnedRooms[x - 1, y].DoorR.SetActive(false);
    			}
    			if (x < n && spawnedRooms[x + 1, y] != null) {
    				spawnedRooms[x, y].DoorR.SetActive(false);
    				spawnedRooms[x + 1, y].DoorL.SetActive(false);
    			}
    			if (y > 0 && spawnedRooms[x, y - 1] != null) {
    				spawnedRooms[x, y].DoorD.SetActive(false);
    				spawnedRooms[x, y - 1].DoorU.SetActive(false);
    			}
    			if (y < n && spawnedRooms[x, y + 1] != null) {
    				spawnedRooms[x, y].DoorU.SetActive(false);
    				spawnedRooms[x, y + 1].DoorD.SetActive(false);
    			}
    		}
    	}
    }
}
