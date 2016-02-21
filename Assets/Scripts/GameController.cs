using UnityEngine;
using System.Collections;
    
public class GameController : MonoBehaviour
{
    public Transform playerSpawn;
    public GameObject playerShip;

	private void Start()
    {
        Instantiate(playerShip, playerSpawn.position, playerSpawn.rotation);
    }
}
