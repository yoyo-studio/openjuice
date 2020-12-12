// Copyright (c) 2020 Omid Saadat (@omid3098)
using DG.Tweening;
using UnityEngine;

namespace OpenJuice
{
    public class ScaleTransition : BaseTransition
    {
        [SerializeField] Vector3 targetScale = Vector3.one;

        public Vector3 TargetScale
        {
            get => targetScale;
            set
            {
                targetScale = value;
                if (tween != null) tween.ChangeEndValue(targetScale);
            }
        }

        protected override Tweener MakeTweener()
        {
            tween = transform.DOScale(TargetScale, Duration).SetEase(EaseType).SetLoops(Loop, LoopType).SetDelay(Delay).SetAutoKill(false);
            if (TransitionType == TransitionType.From) tween.From(Relative);
            else tween.SetRelative(Relative);
            return tween;
        }
    }
}