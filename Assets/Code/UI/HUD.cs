using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Image weaponImage;
    [SerializeField] private Text scoreText;
    [SerializeField] private Image fadeImage;

    public void UpdateHealth(float hpPercentage)
    {
        healthSlider.value = hpPercentage;
    }

    public void UpdateWeaponImage(Sprite weaponSprite)
    {
        weaponImage.sprite = weaponSprite;
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public IEnumerator Fade(float fadeTime)
    {
        fadeImage.color = Color.clear;
        Color newColor = fadeImage.color;
        float timer = 0f;

        while (timer < fadeTime)
        {
            newColor.a = timer / fadeTime;
            fadeImage.color = newColor;
            timer += Time.deltaTime;
            yield return null;
        }
    }

    public void HideFade()
    {
        fadeImage.color = Color.clear;
    }
}