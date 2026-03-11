using UnityEngine;

public interface IKitchenObjectParent {


    public Transform GetKitchenObjectFollowTransform();

    public bool HasKitchenObject();

    public void SetKitchenObject(KitchenObject kitchenObject);

    public KitchenObject GetKitchenObject();

    public void ClearKitchenObject();

}
