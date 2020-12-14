using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Teleport : MonoBehaviour
{
	// Source code help https://www.youtube.com/watch?v=cuQao3hEKfs
	public Transform player;
	public Transform reciever;

	public bool negative;

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			Vector3 portalToPlayer = player.position - transform.position;
			float dotProduct = Vector3.Dot(transform.forward, portalToPlayer);

            if (dotProduct > 0 && negative)
            {
				player.position = reciever.position + portalToPlayer;
            }
            else if (dotProduct < 0 && !negative)
            {
				player.position = reciever.position + portalToPlayer;
			}
		}
	}

}
