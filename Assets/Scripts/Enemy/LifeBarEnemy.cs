using UnityEngine;
using UnityEngine.UI;

public class LifeBarEnemy : MonoBehaviour
{
    [SerializeField]
    public Slider slider;
    private Image fillColor;
    private EnemyController lifeEnemy;

    public Color32 life100;
    public Color32 life48;
    public Color32 life15;

    private void OnValidate()
    {
        slider = GameObject.Find("EnemyLife_Slider").GetComponent<Slider>();
        fillColor = GameObject.Find("Fill_EnemyHP").GetComponent<Image>();        
        lifeEnemy = GetComponent<EnemyController>();
    }
    
    private void Start()
    {
        slider.maxValue = lifeEnemy.enemyLifeMAX;
    }

    private void Update()
    {
        slider.value = lifeEnemy.enemyLife;
    }
    

    private void SliderColor()
    {
        if (lifeEnemy.enemyLifeMAX <= 48)
        {
            fillColor.color = life48;
        }
        else if (lifeEnemy.enemyLifeMAX <= 15)
        {
            fillColor.color = life15;
        }
        else
        {
            fillColor.color = life100;
        }
    }
}
