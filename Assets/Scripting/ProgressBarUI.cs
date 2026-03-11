using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour {

    [SerializeField] private CuttingCounter cuttingCounter;
    [SerializeField] private Image progressBar;

    private void Start() {
        cuttingCounter.OnProgressBarChanged += CuttingCounter_OnProgressBarChanged;
        progressBar.fillAmount = 0f;
        Hide();
    }

    private void CuttingCounter_OnProgressBarChanged(object sender, CuttingCounter.OnProgressBarChangedEventArgs e) {
        progressBar.fillAmount = e.progressNormalized;
        if (e.progressNormalized == 0 || e.progressNormalized == 1) {
            Hide();
        } else {
            Show();
        }
    }

    private void Show() {
        gameObject.SetActive(true);
    }
    private void Hide() {
        gameObject.SetActive(false);
    }
}
