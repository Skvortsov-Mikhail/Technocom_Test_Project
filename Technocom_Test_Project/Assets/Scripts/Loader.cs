using UnityEngine;

public class Loader : MonoBehaviour
{
    [SerializeField] private GameObject m_menu;
    [SerializeField] private GameObject m_levels;
    [SerializeField] private GameObject m_shop;

    private void Start()
    {
        m_menu.SetActive(true);
        m_levels.SetActive(false);
        m_shop.SetActive(false);
    }
}
