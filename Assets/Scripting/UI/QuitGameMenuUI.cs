using UnityEngine;
using UnityEngine.UI;

public class QuitGameMenuUI : MonoBehaviour {

    [SerializeField] private Button confirmQuitButton;
    [SerializeField] private Button cancleQuitButton;

    private void Awake() {
        confirmQuitButton.onClick.AddListener(() => {
            Debug.Log("Application Closed");
            Application.Quit();
        });

        cancleQuitButton.onClick.AddListener(() => {
            HideQuitMenu();
        });
    }

    private void HideQuitMenu() {
        gameObject.SetActive(false);
    }

}