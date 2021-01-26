using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using System;

public class BlinkSpriteRenderer : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] float blinkDuration = 1f;
    private Color basecolor;
    private float ellaspedTime = 0;

    private TweenerCore<Color, Color, ColorOptions> tween;

    private void Awake()
    {
        basecolor = spriteRenderer.color;
    }

    private void Update()
    {
        ellaspedTime += Time.deltaTime;
        if (ellaspedTime >= blinkDuration)
        {
            if (spriteRenderer.color.a == basecolor.a) spriteRenderer.color = Color.clear;
            else spriteRenderer.color = basecolor;
            ellaspedTime = 0;
        }
    }
}
