// Copyright (c) 2020 Omid Saadat (@omid3098)
using DG.Tweening;
using UnityEngine;

namespace YoYoStudio.OpenJuice
{
    public class RotateTransition : BaseTransition
    {
        [SerializeField] Vector3 targetRotation = Vector3.zero;

        public Vector3 TargetRotation
        {
            get => targetRotation;
            set
            {
                targetRotation = value;
                if (tween != null) tween.ChangeEndValue(targetRotation);
            }
        }

        protected override Tweener MakeTweener()
        {
            tween = transform.DOLocalRotate(TargetRotation, Duration).SetEase(EaseType).SetLoops(Loop, LoopType).SetDelay(Delay).SetAutoKill(false);
            if (TransitionType == TransitionType.From) tween.From(Relative);
            else tween.SetRelative(Relative);
            return tween;
        }
    }
}