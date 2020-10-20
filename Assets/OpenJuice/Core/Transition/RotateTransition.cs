// Copyright (c) 2020 Omid Saadat (@omid3098)
using DG.Tweening;
using UnityEngine;

namespace OpenJuice
{
    public class RotateTransition : BaseTransition
    {
        [SerializeField] Vector3 targetRotation = Vector3.zero;
        protected override Tweener MakeTweener()
        {
            if (transitionType == TransitionType.To)
            {
                return relative == false ? MakeTweener(targetRotation) : MakeTweener(targetRotation).SetRelative();
            }
            else
            {
                if (relative == false)
                {
                    var startRotation = transform.localRotation.eulerAngles;
                    transform.Rotate(targetRotation);
                    return MakeTweener(startRotation);
                }
                else
                {
                    transform.Rotate(targetRotation);
                    return MakeTweener(transform.position - targetRotation);
                }
            }
        }

        private Tweener MakeTweener(Vector3 target)
        {
            return transform.DOLocalRotate(target, duration).SetEase(easeType).SetLoops(loop, loopType).SetDelay(delay);
        }
    }
}