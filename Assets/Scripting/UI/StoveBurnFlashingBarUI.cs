using UnityEngine;

public class StoveBurnFlashingBarUI : MonoBehaviour {

    [SerializeField] private StoveCounter stoveCounter;

    private const string IS_FLASHING = "IsFlashing";

    private Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    private void Start() {
        stoveCounter.OnProgressBarChanged += StoveCounter_OnProgressBarChanged;

        animator.SetBool(IS_FLASHING, false);
    }

    private void StoveCounter_OnProgressBarChanged(object sender, IHasProgress.OnProgressBarChangedEventArgs e) {
        float burnShowProgressAmount = 0.5f;
        bool show = stoveCounter.IsFried() && e.progressNormalized > burnShowProgressAmount;

        animator.SetBool(IS_FLASHING, show);
    }

}