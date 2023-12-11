using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Zenject;

public class Level : MonoBehaviour
{
    [SerializeField] private int m_levelNumber;

    [SerializeField] private TMP_Text _levelNumberText;

    [SerializeField] private GameObject m_Locker;

    private Button _passLevelButton;

    private bool _isPassed = false;
    public bool IsPassed => _isPassed;

    private LevelsInfo _levelsInfo;

    [Inject]
    public void Construct(LevelsInfo levelsInfo)
    {
        _levelsInfo = levelsInfo;
    }

    private void Start()
    {
        _levelNumberText.text = m_levelNumber.ToString();

        _passLevelButton = GetComponentInChildren<Button>();
        _passLevelButton.onClick.AddListener(PassLevel);
    }

    private void PassLevel()
    {
        _isPassed = true;

        _levelsInfo.SetLastPassedLevel(m_levelNumber);
    }

    public void DisableLocker()
    {
        m_Locker.SetActive(false);
    }
}