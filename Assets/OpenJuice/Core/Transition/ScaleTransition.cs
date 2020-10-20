// Copyright (c) 2020 Omid Saadat (@omid3098)
using DG.Tweening;
using UnityEngine;

namespace OpenJuice
{
    public class ScaleTransition : BaseTransition
    {
        [SerializeField] Vector3 targetScale = Vector3.one;
        protected override Tweener MakeTweener()
        {
            if (transitionType == TransitionType.To)
            {
                return relative == false ? MakeTweener(targetScale) : MakeTweener(targetScale).SetRelative();
            }
            else
            {
                if (relative == false)
                {
                    var startScale = transform.localScale;
                    transform.localScale = targetScale;
                    return MakeTweener(startScale);
                }
                else
                {
                    transform.localScale += targetScale;
                    return MakeTweener(transform.localScale - targetScale);
                }
            }
        }
        private Tweener MakeTweener(Vector3 target)
        {
            return transform.DOScale(target, duration).SetEase(easeType).SetLoops(loop, loopType).SetDelay(delay);
        }
    }
}