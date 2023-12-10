using UnityEngine;
using Zenject;
using TMPro;

public class DailyReward : MonoBehaviour
{
    [SerializeField] private int m_dayIndex;
    public int DayIndex => m_dayIndex;

    [SerializeField] private int m_value;

    [SerializeField] private TMP_Text m_dayText;
    [SerializeField] private TMP_Text m_valueText;

    private DailyRewardManager _dailyRewardManager;
    private TicketsController _ticketsController;

    [Inject]
    public void Construct(DailyRewardManager dailyRewardManager, TicketsController ticketsController)
    {
        _dailyRewardManager = dailyRewardManager;
        _ticketsController = ticketsController;
    }

    private void Start()
    {
        _dailyRewardManager.RewardClaimed += ClaimReward;

        m_dayText.text = "DAY" + (m_dayIndex + 1).ToString();
        m_valueText.text = "X" + m_value.ToString();
    }

    private void OnDestroy()
    {
        _dailyRewardManager.RewardClaimed -= ClaimReward;
    }

    public void ClaimReward(int currentStreak)
    {
        if (currentStreak == m_dayIndex)
        {
            _ticketsController.AddTickets(m_value);
        }

        if (currentStreak == _dailyRewardManager.DailyRewardCount - 1)
        {
            FindObjectOfType<UI_DailyRewardsView>(true).OpenWeeklyRewardPanel();
        }
    }
}