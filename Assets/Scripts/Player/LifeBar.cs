using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    [SerializeField]
    private Slider slider;
    private Image fillColor;
    private PlayerController lifePlayer;

    public Color32 life100;
    public Color32 life48;
    public Color32 life15;

//----------------------------------------------------//
    private void Awake()
    {
        slider = GameObject.Find("PlayerLife_Slider").GetComponent<Slider>();
        fillColor = GameObject.Find("Fill_PlayerHP").GetComponent<Image>();        
        lifePlayer = GetComponent<PlayerController>();
    }
    
    private void Start()
    {
        slider.maxValue = lifePlayer.playerLifeMAX;
    }

    private void Update()
    {
        slider.value = lifePlayer.playerLife;
        SliderColor();
    }
    
//------------------------------------------------------//

    private void SliderColor()
    {
        if (lifePlayer.playerLifeMAX <= 48)
        {
            fillColor.color = life48;
        }
        else if (lifePlayer.playerLifeMAX <= 15)
        {
            fillColor.color = life15;
        }
        else
        {
            fillColor.color = life100;
        }
    }
}
