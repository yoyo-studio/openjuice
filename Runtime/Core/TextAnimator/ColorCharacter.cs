// Copyright (c) 2020 Omid Saadat (@omid3098)
using DG.Tweening;
using UnityEngine;
namespace YoYoStudio.OpenJuice.TextAnimator
{
    public class ColorCharacter : TextAnimatorBase
    {
        [SerializeField] Color targetColor = Color.green;
        protected override Tweener ApplyCharTween(int i)
        {
            return charTween.DOColor(i, targetColor, duration)
                                 .SetDelay(i * chatacterDelay)
                                 .SetEase(easeType)
                                 .SetLoops(loopCount, loopType);
        }
    }
}