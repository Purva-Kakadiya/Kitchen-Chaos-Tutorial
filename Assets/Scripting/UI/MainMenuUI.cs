using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour {

    [SerializeField] private Button playButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private QuitGameMenuUI quitGameMenuUI;

    private void Awake() {
        playButton.onClick.AddListener(() => {
            Loader.LoadScene(Loader.Scene.GameScene);
        });

        quitButton.onClick.AddListener(() => {
            ShowQuitGameMenu();
        });

        HideQuitGameMenu();
    }

    private void ShowQuitGameMenu() {
        quitGameMenuUI.gameObject.SetActive(true);
    }

    private void HideQuitGameMenu() {
        quitGameMenuUI.gameObject.SetActive(false);
    }

}