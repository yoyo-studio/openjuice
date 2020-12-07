// Copyright (c) 2020 Omid Saadat (@omid3098)
using DG.Tweening;
using UnityEngine;

namespace OpenJuice.TextAnimator
{
    public class BounceCharacters : TextAnimatorBase
    {
        [SerializeField] protected Vector3 targetValue = Vector3.zero;
        protected override Tweener ApplyCharTween(int i)
        {
            return charTween.DOMove(i, targetValue, duration)
                                 .SetDelay(i * chatacterDelay)
                                 .SetEase(easeType)
                                 .SetLoops(loopCount, loopType)
                                 .SetRelative();
        }
    }
}