using TMPro;
using UnityEngine;

public class TopBar : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_PlayerName;
    [SerializeField] private TextMeshProUGUI m_Coin;
    // Start is called before the first frame update
    void Start()
    {
        m_PlayerName.text = PlayerProfile.Instance.GetPlayerName();
        m_Coin.text = PlayerProfile.Instance.GetCurrentCoin().ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnEnable()
    {
        PlayerProfile.ON_COIN_CHANGE += OnCoinChange;
    }
    private void OnDisable()
    {
        PlayerProfile.ON_COIN_CHANGE -= OnCoinChange;

    }
    private void OnCoinChange()
    {
        m_Coin.text = PlayerProfile.Instance.GetCurrentCoin().ToString();

    }
}
