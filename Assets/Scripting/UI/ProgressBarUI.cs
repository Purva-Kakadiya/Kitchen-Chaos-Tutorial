using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour {

    [SerializeField] private GameObject hasProgressGameObject;
    [SerializeField] private Image progressBar;

    private IHasProgress hasProgress;
    private void Start() {
        hasProgress = hasProgressGameObject.GetComponent<IHasProgress>();
        if (hasProgress == null) {
            Debug.LogError("GameObject " + hasProgressGameObject.name + " does not have a IHasProgress component!");
        }

        hasProgress.OnProgressBarChanged += HasProgress_OnProgressBarChanged;
        progressBar.fillAmount = 0f;
        Hide();
    }

    private void HasProgress_OnProgressBarChanged(object sender, IHasProgress.OnProgressBarChangedEventArgs e) {
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
