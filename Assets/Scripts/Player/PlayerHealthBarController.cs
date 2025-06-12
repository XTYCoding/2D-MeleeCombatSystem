using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerHealthBarController : MonoBehaviour
{
    [SerializeField]public Entity player;
    private RectTransform rectTransform;
    private Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        slider = GetComponentInChildren<Slider>();

        UpdateHealthUI();
        player.takeDamage += UpdateHealthUI;
    }

    private void UpdateHealthUI()
    {
        slider.maxValue = player.stat.maxHP.GetValue();
        slider.value = player.stat.currentHP.GetValue();
    }

    private void FlipUI() => rectTransform.Rotate(0, 180, 0);

    private void OnDisable() {
        player.takeDamage -= UpdateHealthUI;
    }
}
