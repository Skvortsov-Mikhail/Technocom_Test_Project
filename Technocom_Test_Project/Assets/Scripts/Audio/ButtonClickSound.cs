using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonClickSound : MonoBehaviour
{
    private AudioSource m_sound;
    private Button _button;

    private void Start()
    {
        m_sound = GameObject.Find("Button Click Sound").GetComponent<AudioSource>();

        _button = GetComponent<Button>();
        _button.onClick.AddListener(PlaySound);
    }

    private void PlaySound()
    {
        m_sound.Play();
    }
}