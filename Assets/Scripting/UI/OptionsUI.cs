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

    [SerializeField] private Button gamePadInteractButton;
    [SerializeField] private Button gamePadInteractAlternateButton;
    [SerializeField] private Button gamePadPauseButton;

    [SerializeField] private TextMeshProUGUI moveUpText;
    [SerializeField] private TextMeshProUGUI moveDownText;
    [SerializeField] private TextMeshProUGUI moveLeftText;
    [SerializeField] private TextMeshProUGUI moveRightText;
    [SerializeField] private TextMeshProUGUI interactText;
    [SerializeField] private TextMeshProUGUI interactAlternateText;
    [SerializeField] private TextMeshProUGUI pauseText;

    [SerializeField] private TextMeshProUGUI gamePadInteractText;
    [SerializeField] private TextMeshProUGUI gamePadInteractAlternateText;
    [SerializeField] private TextMeshProUGUI gamePadPauseText;

    [SerializeField] private Image moveUpRebindImage;
    [SerializeField] private Image moveDownRebindImage;
    [SerializeField] private Image moveLeftRebindImage;
    [SerializeField] private Image moveRightRebindImage;
    [SerializeField] private Image interactRebindImage;
    [SerializeField] private Image interactAlternateRebindImage;
    [SerializeField] private Image pauseRebindImage;

    [SerializeField] private Image gamePadInteractRebindImage;
    [SerializeField] private Image gamePadInteractAlternateRebindImage;
    [SerializeField] private Image gamePadPauseRebindImage;

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
        gamePadInteractButton.onClick.AddListener(() => {
            RebindBinding(GameInput.Binding.GamePad_Interact);
        });
        gamePadInteractAlternateButton.onClick.AddListener(() => {
            RebindBinding(GameInput.Binding.GamePad_InteractAlternate);
        });
        gamePadPauseButton.onClick.AddListener(() => {
            RebindBinding(GameInput.Binding.GamePad_Pause);
        });
    }

    private void Start() {

        UpdateVisual();
        HideRebindImage(moveUpRebindImage);
        HideRebindImage(moveDownRebindImage);
        HideRebindImage(moveLeftRebindImage);
        HideRebindImage(moveRightRebindImage);
        HideRebindImage(interactRebindImage);
        HideRebindImage(interactAlternateRebindImage);
        HideRebindImage(pauseRebindImage);

        HideRebindImage(gamePadInteractRebindImage);
        HideRebindImage(gamePadInteractAlternateRebindImage);
        HideRebindImage(gamePadPauseRebindImage);
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

        gamePadInteractText.text = GameInput.Instance.GetBindingText(GameInput.Binding.GamePad_Interact);
        gamePadInteractAlternateText.text = GameInput.Instance.GetBindingText(GameInput.Binding.GamePad_InteractAlternate);
        gamePadPauseText.text = GameInput.Instance.GetBindingText(GameInput.Binding.GamePad_Pause);
    }

    public void Show() {
        GamePausedUI.Instance.Hide();
        isOptionMenuActive = true;
        gameObject.SetActive(true);

        soundEffectButton.Select();
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
                ShowRebindImage(moveUpRebindImage);
                GameInput.Instance.RebindBinding(binding, () => { 
                    HideRebindImage(moveUpRebindImage);
                    UpdateVisual();
                });
                break;
            case GameInput.Binding.Move_Down:
                ShowRebindImage(moveDownRebindImage);
                GameInput.Instance.RebindBinding(binding, () => {
                    HideRebindImage(moveDownRebindImage);
                    UpdateVisual();
                });
                break;
            case GameInput.Binding.Move_Left:
                ShowRebindImage(moveLeftRebindImage);
                GameInput.Instance.RebindBinding(binding, () => {
                    HideRebindImage(moveLeftRebindImage);
                    UpdateVisual();
                });
                break;
            case GameInput.Binding.Move_Right:
                ShowRebindImage(moveRightRebindImage);
                GameInput.Instance.RebindBinding(binding, () => {
                    HideRebindImage(moveRightRebindImage);
                    UpdateVisual();
                });
                break;
            case GameInput.Binding.Interact:
                ShowRebindImage(interactRebindImage);
                GameInput.Instance.RebindBinding(binding, () => {
                    HideRebindImage(interactRebindImage);
                    UpdateVisual();
                });
                break;
            case GameInput.Binding.InteractAlternate:
                ShowRebindImage(interactAlternateRebindImage);
                GameInput.Instance.RebindBinding(binding, () => {
                    HideRebindImage(interactAlternateRebindImage);
                    UpdateVisual();
                });
                break;
            case GameInput.Binding.Pause:
                ShowRebindImage(pauseRebindImage);
                GameInput.Instance.RebindBinding(binding, () => {
                    HideRebindImage(pauseRebindImage);
                    UpdateVisual();
                });
                break;
            case GameInput.Binding.GamePad_Interact:
                ShowRebindImage(gamePadInteractRebindImage);
                GameInput.Instance.RebindBinding(binding, () => {
                    HideRebindImage(gamePadInteractRebindImage);
                    UpdateVisual();
                });
                break;
            case GameInput.Binding.GamePad_InteractAlternate:
                ShowRebindImage(gamePadInteractAlternateRebindImage);
                GameInput.Instance.RebindBinding(binding, () => {
                    HideRebindImage(gamePadInteractAlternateRebindImage);
                    UpdateVisual();
                });
                break;
            case GameInput.Binding.GamePad_Pause:
                ShowRebindImage(gamePadPauseRebindImage);
                GameInput.Instance.RebindBinding(binding, () => {
                    HideRebindImage(gamePadPauseRebindImage);
                    UpdateVisual();
                });
                break;
        }
    }

}