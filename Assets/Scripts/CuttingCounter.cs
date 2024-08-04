using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter {

    [SerializeField] private KitchenObjectSO cutKitchenObjectSO;

    public override void Interact(Player player) {
        if (!HasKitchenObject()) {
            if (player.HasKitchenObject()) {
                // drop kitchen object from player to this clear counter
                player.GetKitchenObject().SetKitchenObjectParent(this);
            } else {
                // do nothing
            }
        } else {
            if (player.HasKitchenObject()) {
                // do nothing
            } else {
                // give the kitchen object on this clear counter to the player
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }

    public override void InteractAlternate(Player player) {
        // destroy original kitchen object
        if (HasKitchenObject()) {
            GetKitchenObject().DestroySelf();
        }

        // spawn cut kitchen object
        KitchenObject.SpawnKitchenObject(cutKitchenObjectSO, this);
    }

}