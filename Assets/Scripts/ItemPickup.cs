using UnityEngine;

public class ItemPickup : Interactable {
    public Item item;

    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    void PickUp ()
    {
        Debug.Log("Picking up " + item.name);
        // Add Item to Inventory.
        bool wasPickedUp = Inventory.instance.Add(item);

        // If item was picked up, remove from screen.
        if (wasPickedUp)
            Destroy(gameObject);

    }
}
