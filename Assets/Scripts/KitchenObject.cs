using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour {

    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    private ClearCounter clearCounter;

    public KitchenObjectSO GetKitchenObjectSO() {
        return kitchenObjectSO;
    }

    public void SetClearCounter(ClearCounter clearCounter) {
        // tell the previous clear counter that this kitchen object is no longer on top of it
        if (this.clearCounter != null) {
            this.clearCounter.ClearKitchenObject();
        }

        this.clearCounter = clearCounter;

        // tell the new clear counter that this kitchen object is now on top of it
        if (clearCounter.HasKitchenObject()) {
            Debug.LogError("Counter already has a KitchenObject!");
        }
        clearCounter.SetKitchenObject(this);

        transform.parent = clearCounter.GetKitchenObjectFollowTransform();
        transform.localPosition = Vector3.zero;
    }

    public ClearCounter GetClearCounter() {
        return clearCounter;
    }

}