using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Image foregroundImage;
    [SerializeField]
    private float speed;

    void Awake()
    {
        GetComponentInParent<EnemyInstance>().HealthChanged += UpdateHealthBar;
    }

    private void UpdateHealthBar(float pct)
    {
        StopAllCoroutines();
        StartCoroutine(ChangeToPct(pct));
    }

    private void LateUpdate()
    {
        transform.LookAt(Camera.main.transform);
        transform.Rotate(0, 180, 0);
    }

    private IEnumerator ChangeToPct(float amount)
    {
        float preChangeAmount = foregroundImage.fillAmount;
        float elapsed = 0.0f;
        while (elapsed < speed)
        {
            elapsed += Time.deltaTime;
            foregroundImage.fillAmount = Mathf.Lerp(preChangeAmount, amount, speed);
            yield return null;
        }
        foregroundImage.fillAmount = amount;
    }

}
