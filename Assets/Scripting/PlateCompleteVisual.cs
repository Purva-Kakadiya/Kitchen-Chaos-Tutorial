using NUnit.Framework;
using UnityEngine;
using System;
using System.Collections.Generic;

public class PlateCompleteVisual : MonoBehaviour {

    [Serializable] public struct KitchenObjectSO_GameObject {

        public KitchenObjectSO kitchenObjectSO;
        public GameObject gameObject;

    }

    [SerializeField] private PlateKitchenObject plateKitchenObject;
    [SerializeField] private List<KitchenObjectSO_GameObject> kitchenObjectGameObjectList;

    private void Start() {
        plateKitchenObject.OnIngredientAdded += PlateKitchenObject_OnIngredientAdded;

        foreach (KitchenObjectSO_GameObject kitchenObjectGameObject in kitchenObjectGameObjectList) {
            kitchenObjectGameObject.gameObject.SetActive(false);
        }
    }

    private void PlateKitchenObject_OnIngredientAdded(object sender, PlateKitchenObject.OnIngredientAddedEventArgs e) {
        foreach(KitchenObjectSO_GameObject kitchenObjectGameObject in kitchenObjectGameObjectList) {
            if(kitchenObjectGameObject.kitchenObjectSO == e.kitchenObjectSO) {
                kitchenObjectGameObject.gameObject.SetActive(true);
            }
        }
    }
}
