using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using TMPro;

public class UI_DailyRewardsView : MonoBehaviour
{
    [SerializeField] private TMP_Text m_nextRewardTimer;
    [SerializeField] private Button m_claimButton;

    [SerializeField] private Color m_defaultColor;
    [SerializeField] private Color m_currentColor;

    [SerializeField] private Image m_progressBarFill;
    [SerializeField] private TMP_Text m_progressBarText;

    [SerializeField] private GameObject m_weeklyRewardPanel;

    private DailyReward[] rewards;

    private DailyRewardManager _dailyRewardManager;

    [Inject]
    public void Construct(DailyRewardManager dailyRewardManager)
    {
        _dailyRewardManager = dailyRewardManager;
    }

    private void Start()
    {
        _dailyRewardManager.RewardStateUpdated += UpdateRewardUI;

        rewards = GetComponentsInChildren<DailyReward>();

        m_claimButton.onClick.AddListener(_dailyRewardManager.ClaimReward);

        UpdateRewardUI();
    }

    private void OnDestroy()
    {
        _dailyRewardManager.RewardStateUpdated -= UpdateRewardUI;
    }

    private void UpdateRewardUI()
    {
        if (!isActiveAndEnabled) return;

        int currentStreak = _dailyRewardManager.CurrentStreak;
        int maxStreak = _dailyRewardManager.DailyRewardCount;
        bool canClaimReward = _dailyRewardManager.CanClaimReward;

        foreach (var reward in rewards)
        {
            if (reward.GetComponent<Image>() != null)
            {
                reward.GetComponent<Image>().color = reward.DayIndex == currentStreak ? m_currentColor : m_defaultColor;
            }
        }

        m_progressBarFill.fillAmount = (float)currentStreak / maxStreak;
        m_progressBarText.text = currentStreak.ToString() + "/" + maxStreak.ToString();

        m_claimButton.interactable = canClaimReward;

        if (canClaimReward)
        {
            m_nextRewardTimer.text = "[Get your reward]";
        }
        else
        {
            var currentClaimCooldown = DateTime.MaxValue - DateTime.UtcNow.AddHours(_dailyRewardManager.AddHoursToUtcForMoscowTime);

            string cd = $"{currentClaimCooldown.Hours:D2}:{currentClaimCooldown.Minutes:D2}:{currentClaimCooldown.Seconds:D2}";

            m_nextRewardTimer.text = $"[Next reward in {cd}]";
        }
    }

    public void OpenWeeklyRewardPanel()
    {
        m_weeklyRewardPanel.SetActive(true);
        gameObject.SetActive(false);
    }
}