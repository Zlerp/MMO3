using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

    //How close a player needs to be to interact with an object or NPC
    public float radius = 3f;

    // Boolean to check if user is focused on something already.
    bool isFocus = false;


    Transform player;

    public Transform interactionTransform;
    bool hasInteracted = false;

    public virtual void Interact ()
    {
        // this will choose the type of interaction that is done.
        // This is meant to be overwritten.
        Debug.Log("Interacting with " + transform.name);
  
    }

    void Update ()
    {
        // check if it is Focused and if interacted
        if (isFocus && !hasInteracted)
        {
            // checked IF OBJECT INTERACTABLE DISTANCE
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            if (distance <= radius)
            {
                // if its within the distance, then interact.
                Interact();
                Debug.Log("INTERACT...");
                hasInteracted = true;
            }
        }
    }
    public void OnFocused (Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }

    public void OnDeFocused ()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }

    private void OnDrawGizmosSelected()
    {

        if (interactionTransform == transform)
        {
            interactionTransform = transform;
        }
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}
