using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    private Slider slider;
    private PlayerCharacter character;

    void Start()
    {
        slider = GetComponent<Slider>();
        character = GameObject.Find("Player").GetComponent<CharacterInstance>().player;
        slider.maxValue = character.HitPoints;
        slider.value = slider.maxValue;
        character.HitPointsChanged += UpdateHealthbar;
    }

    private void UpdateHealthbar(int value)
    {
        this.slider.value = value;
    }
}
