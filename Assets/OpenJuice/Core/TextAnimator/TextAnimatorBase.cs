// Copyright (c) 2020 Omid Saadat (@omid3098)
using System;
using CharTween;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UnityEngine;
namespace OpenJuice.TextAnimator
{
    public abstract class TextAnimatorBase : MonoBehaviour
    {
        private TMP_Text text;
        protected CharTweener charTween;
        [SerializeField] protected Ease easeType = Ease.OutBounce;
        [SerializeField] protected float duration = 1f;
        [SerializeField] protected float chatacterDelay = 0.1f;
        [SerializeField] protected float intervalDelay = 1f;
        [SerializeField] protected int loopCount = -1;
        [SerializeField] protected LoopType loopType = LoopType.Yoyo;

        private void Awake()
        {
            text = GetComponent<TMP_Text>();
            charTween = text.GetCharTweener();
            StartCharacterTween();
        }

        private void StartCharacterTween()
        {
            for (var i = 0; i < charTween.CharacterCount; i++)
            {
                ApplyCharTween(i);
            }
        }
        protected abstract Tweener ApplyCharTween(int characterIndex);
    }
}