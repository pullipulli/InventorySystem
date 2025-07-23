using UnityEngine;
using UnityEngine.UI;

public class TooltipShower : MonoBehaviour
{
    public static TooltipShower Instance { get; private set; }
    private Text _tooltipText;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else Destroy(this);
    }
    void Start()
    {
        _tooltipText = transform.GetChild(0).GetComponent<Text>();
        gameObject.SetActive(false);
    }

    public void ShowTooltip(Vector2 tooltipPosition, string message)
    {
        _tooltipText.text = message;
        transform.position = tooltipPosition;
        gameObject.SetActive(true);
    }

    public void HideTooltip()
    {
        gameObject.SetActive(false);
    }
}
