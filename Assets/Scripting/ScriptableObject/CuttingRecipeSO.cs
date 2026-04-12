using UnityEngine;

[CreateAssetMenu(fileName = "CuttingReciepySO", menuName = "Scriptable Objects/CuttingReciepySO")]
public class CuttingRecipeSO : ScriptableObject {

    public KitchenObjectSO input;
    public KitchenObjectSO output;
    public int cuttingProgressMax;

}
