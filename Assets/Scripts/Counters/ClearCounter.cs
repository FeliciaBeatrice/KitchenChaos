using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter {

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

}