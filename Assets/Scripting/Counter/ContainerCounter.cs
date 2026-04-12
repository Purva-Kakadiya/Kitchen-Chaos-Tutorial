using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ContainerCounter : BaseCounter {

    public event EventHandler OnPlayerGrabbedObject;

    [SerializeField] private KitchenObjectSO kichenObjectSO;

    public override void Interact(Player player) {
        if (!player.HasKitchenObject()) {

            KitchenObject.SpawnKitchenObject(kichenObjectSO, player);

            OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
        }
    }

}
