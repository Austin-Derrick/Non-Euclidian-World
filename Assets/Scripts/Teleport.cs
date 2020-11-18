using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Teleport : MonoBehaviour
{
	// Source code help https://www.youtube.com/watch?v=cuQao3hEKfs
	public Transform player;
	public BoxCollider reciever;

	private bool playerIsOverlapping = false;
	int counter = 0;
	// Update is called once per frame
	void Update()
	{
		if (playerIsOverlapping && counter == 1)
		{
			Vector3 portalToPlayer = player.position - transform.position;
			float dotProduct = Vector3.Dot(transform.up, portalToPlayer);
            // If this is true: The player has moved across the portal
            if (dotProduct < 0f)
            {
				float rotationDiff = -Quaternion.Angle(transform.rotation, reciever.transform.rotation);
				rotationDiff += 180;
				player.Rotate(Vector3.up, rotationDiff);

				Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer; //+ new Vector3(0, 0, 5);
				player.position = reciever.transform.position + positionOffset;

				playerIsOverlapping = false;
            }
			counter++;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			playerIsOverlapping = true;
			counter = 1;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			playerIsOverlapping = false;
			counter = 0;
		}
	}

}
