using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    private Entity entity;
    private RectTransform rectTransform;
    private Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        entity = GetComponentInParent<Entity>();
        rectTransform = GetComponent<RectTransform>();
        slider = GetComponentInChildren<Slider>();

        UpdateHealthUI();
        entity.onFlipped += FlipUI;
        entity.takeDamage += UpdateHealthUI;
    }

    private void UpdateHealthUI()
    {
        slider.maxValue = entity.stat.maxHP.GetValue();
        slider.value = entity.stat.currentHP.GetValue();
    }

    private void FlipUI() => rectTransform.Rotate(0, 180, 0);

    private void OnDisable() {
        entity.onFlipped -= FlipUI;
        entity.takeDamage -= UpdateHealthUI;
    }


}
