using UnityEngine;

public class StoveBurnWarningUI : MonoBehaviour {

    [SerializeField] private StoveCounter stoveCounter;

    private void Start() {
        stoveCounter.OnProgressBarChanged += StoveCounter_OnProgressBarChanged;

        Hide();
    }

    private void StoveCounter_OnProgressBarChanged(object sender, IHasProgress.OnProgressBarChangedEventArgs e) {
        float burnShowProgressAmount = 0.5f;
        bool show = stoveCounter.IsFried() && e.progressNormalized > burnShowProgressAmount;

        if(show) {
            Show();
        } else {
            Hide();
        }
    }

    private void Show() {
        gameObject.SetActive(true);
    }

    private void Hide() {
        gameObject.SetActive(false);
    }

}