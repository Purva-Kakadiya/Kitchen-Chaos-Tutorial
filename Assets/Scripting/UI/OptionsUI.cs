using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionsUI : MonoBehaviour {

    public static OptionsUI Instance { get; private set; }

    [SerializeField] private Button soundEffectButton;
    [SerializeField] private Button musicButton;
    [SerializeField] private Button closeButton;
    [SerializeField] private TextMeshProUGUI soundEffectText;
    [SerializeField] private TextMeshProUGUI musicText;

    [SerializeField] private Button moveUpButton;
    [SerializeField] private Button moveDownButton;
    [SerializeField] private Button moveLeftButton;
    [SerializeField] private Button moveRightButton;
    [SerializeField] private Button interactButton;
    [SerializeField] private Button interactAlternateButton;
    [SerializeField] private Button pauseButton;

    [SerializeField] private TextMeshProUGUI moveUpText;
    [SerializeField] private TextMeshProUGUI moveDownText;
    [SerializeField] private TextMeshProUGUI moveLeftText;
    [SerializeField] private TextMeshProUGUI moveRightText;
    [SerializeField] private TextMeshProUGUI interactText;
    [SerializeField] private TextMeshProUGUI interactAlternateText;
    [SerializeField] private TextMeshProUGUI pauseText;

    [SerializeField] private Image moveUpRebind;
    [SerializeField] private Image moveDownRebind;
    [SerializeField] private Image moveLeftRebind;
    [SerializeField] private Image moveRightRebind;
    [SerializeField] private Image interactRebind;
    [SerializeField] private Image interactAlternateRebind;
    [SerializeField] private Image pauseRebind;

    private bool isOptionMenuActive = false;

    private void Awake() {
        Instance = this;

        soundEffectButton.onClick.AddListener(() => {
            SoundManager.Instance.ChanageVolume();
            UpdateVisual();
        });
        musicButton.onClick.AddListener(() => {
            MusicManager.Instance.ChanageVolume();
            UpdateVisual();
        });
        closeButton.onClick.AddListener(() => {
            Hide();
        });

        moveUpButton.onClick.AddListener(() => {
            RebindBinding(GameInput.Binding.Move_Up);
        });
        moveDownButton.onClick.AddListener(() => {
            RebindBinding(GameInput.Binding.Move_Down);
        });
        moveLeftButton.onClick.AddListener(() => {
            RebindBinding(GameInput.Binding.Move_Left);
        });
        moveRightButton.onClick.AddListener(() => {
            RebindBinding(GameInput.Binding.Move_Right);
        });
        interactButton.onClick.AddListener(() => {
            RebindBinding(GameInput.Binding.Interact);
        });
        interactAlternateButton.onClick.AddListener(() => {
            RebindBinding(GameInput.Binding.InteractAlternate);
        });
        pauseButton.onClick.AddListener(() => {
            RebindBinding(GameInput.Binding.Pause);
        });
    }

    private void Start() {

        UpdateVisual();
        HideRebindImage(moveUpRebind);
        HideRebindImage(moveDownRebind);
        HideRebindImage(moveLeftRebind);
        HideRebindImage(moveRightRebind);
        HideRebindImage(interactRebind);
        HideRebindImage(interactAlternateRebind);
        HideRebindImage(pauseRebind);
        Hide();
    }

    private void UpdateVisual() {
        soundEffectText.text = "Sound Effects: " + Mathf.Round(SoundManager.Instance.GetVolume() * 10);
        musicText.text = "Music: " + Mathf.Round(MusicManager.Instance.GetVolume() * 10);

        moveUpText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Up);
        moveDownText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Down);
        moveLeftText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Left);
        moveRightText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Right);
        interactText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Interact);
        interactAlternateText.text = GameInput.Instance.GetBindingText(GameInput.Binding.InteractAlternate);
        pauseText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Pause);
    }

    public void Show() {
        GamePausedUI.Instance.Hide();
        isOptionMenuActive = true;
        gameObject.SetActive(true);
    }

    public void Hide() {
        GamePausedUI.Instance.Show();
        isOptionMenuActive = false;
        gameObject.SetActive(false);
    }

    public bool IsOptionMenuActive() {
        return isOptionMenuActive;
    }

    private void ShowRebindImage(Image rebindImage) {
        rebindImage.gameObject.SetActive(true);
    }

    private void HideRebindImage(Image rebindImage) {
        rebindImage.gameObject.SetActive(false);
    }

    private void RebindBinding(GameInput.Binding binding) {

        switch (binding) {
            default:
            case GameInput.Binding.Move_Up:
                ShowRebindImage(moveUpRebind);
                GameInput.Instance.RebindBinding(binding, () => { 
                    HideRebindImage(moveUpRebind);
                    UpdateVisual();
                });
                break;
            case GameInput.Binding.Move_Down:
                ShowRebindImage(moveDownRebind);
                GameInput.Instance.RebindBinding(binding, () => {
                    HideRebindImage(moveDownRebind);
                    UpdateVisual();
                });
                break;
            case GameInput.Binding.Move_Left:
                ShowRebindImage(moveLeftRebind);
                GameInput.Instance.RebindBinding(binding, () => {
                    HideRebindImage(moveLeftRebind);
                    UpdateVisual();
                });
                break;
            case GameInput.Binding.Move_Right:
                ShowRebindImage(moveRightRebind);
                GameInput.Instance.RebindBinding(binding, () => {
                    HideRebindImage(moveRightRebind);
                    UpdateVisual();
                });
                break;
            case GameInput.Binding.Interact:
                ShowRebindImage(interactRebind);
                GameInput.Instance.RebindBinding(binding, () => {
                    HideRebindImage(interactRebind);
                    UpdateVisual();
                });
                break;
            case GameInput.Binding.InteractAlternate:
                ShowRebindImage(interactAlternateRebind);
                GameInput.Instance.RebindBinding(binding, () => {
                    HideRebindImage(interactAlternateRebind);
                    UpdateVisual();
                });
                break;
            case GameInput.Binding.Pause:
                ShowRebindImage(pauseRebind);
                GameInput.Instance.RebindBinding(binding, () => {
                    HideRebindImage(pauseRebind);
                    UpdateVisual();
                });
                break;
        }
    }

}