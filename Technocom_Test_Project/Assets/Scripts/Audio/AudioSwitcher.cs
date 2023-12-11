using UnityEngine;
using UnityEngine.UI;

public class AudioSwitcher : MonoBehaviour
{
    [SerializeField] private AudioSource m_sound;

    [SerializeField] private Sprite m_audioOnIcon;
    [SerializeField] private Sprite m_audioOffIcon;

    private Button _switchButton;
    private Image _switchButtonImage;

    private bool _isAudioPlaying;

    private void Start()
    {
        _switchButton = GetComponent<Button>();
        _switchButtonImage = GetComponent<Image>();

        SetAudioState(true);

        _switchButton.onClick.AddListener(SwitchAudioEnabled);
    }

    private void OnDestroy()
    {
        _switchButton.onClick.RemoveListener(SwitchAudioEnabled);
    }

    private void SwitchAudioEnabled()
    {
        SetAudioState(!_isAudioPlaying);
    }

    private void SetAudioState(bool state)
    {
        m_sound.volume = state ? 1f : 0f;

        _isAudioPlaying = state;

        _switchButtonImage.sprite = state ? m_audioOnIcon : m_audioOffIcon;
    }
}