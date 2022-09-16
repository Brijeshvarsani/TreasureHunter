using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    public Transform RespawnLocation;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided");
        if (other.gameObject.tag == "Player")
        {
            CharacterController cc = other.GetComponent<CharacterController>();

            cc.enabled = false;
            other.gameObject.transform.position = RespawnLocation.position;
            cc.enabled = true;
            // Debug.Log("Teleportion: " + other.gameObject.transform.position + " (" + RespawnLocation.position + ")");
            //Debug.Log("Teleportion1: " + other.gameObject.transform.position + " (" + RespawnLocation.position + ")");
        }
    }
}
