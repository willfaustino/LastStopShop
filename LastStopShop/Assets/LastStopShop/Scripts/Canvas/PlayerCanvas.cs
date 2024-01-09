using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCanvas : MonoBehaviour
{
    #region "Instance"

    private static PlayerCanvas _instance;

    public static PlayerCanvas Instance
    {
        get { return _instance; }
        set
        {
            if (_instance == null)
            {
                _instance = value;
                DontDestroyOnLoad(_instance.gameObject);
            }
        }
    }

    protected virtual void Awake()
    {
        transform.SetParent(null);
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

    }

    #endregion

    [Header("Canvas Player")]
    [SerializeField] private Slider sliderHealthPoints;
    [SerializeField] private Button buttonInventory;
    [SerializeField] private Button buttonConfiguration;
    [SerializeField] private TextMeshProUGUI textCoins;
    [SerializeField] private CanvasGroup canvasGroupInventory;
    [SerializeField] private CanvasGroup canvasGroupConfiguration;

    void Start()
    {
        buttonInventory.onClick.AddListener(ChangeInventoryVisibility);
        buttonConfiguration.onClick.AddListener(ChangeConfigurationVisibility);
    }

    void UpdateCoinsText(string coins)
    {
        textCoins.text = coins;
    }

    public int GetCoinsText() 
    {
        return int.Parse(textCoins.text);
    }

    void OnEnable()
    {
        Player.onUpdateCoins += UpdateCoinsText;
    }

    void OnDisable()
    {
        Player.onUpdateCoins -= UpdateCoinsText;
    }

    void ChangeInventoryVisibility()
    {
        if (canvasGroupInventory.alpha == 1f)
        {
            canvasGroupInventory.Hide();
        }
        else
        {
            canvasGroupInventory.Show();
        }
    }

    void ChangeConfigurationVisibility()
    {
        if (canvasGroupConfiguration.alpha == 1f)
        {
            canvasGroupConfiguration.Hide();
        }
        else
        {
            canvasGroupConfiguration.Show();
        }
    }
}
