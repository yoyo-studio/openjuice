// Copyright (c) 2020 Omid Saadat (@omid3098)

using System;
using System.Collections;
using Cysharp.Threading.Tasks;
using UnityEngine;
namespace YoYoStudio.OpenJuice
{
    public class LightningEffect : Effect
    {
        [SerializeField] GameObject lightGameObject = null;
        public override void PlayStartEffect()
        {
            base.PlayStartEffect();
            StartBlinkEffect();
        }

        private async void StartBlinkEffect()
        {
            await UniTask.Delay(TimeSpan.FromSeconds(0.2f));
            lightGameObject.SetActive(false);
            await UniTask.Delay(TimeSpan.FromSeconds(0.08f));
            lightGameObject.SetActive(true);
            await UniTask.Delay(TimeSpan.FromSeconds(0.3f));
            lightGameObject.SetActive(false);
            await UniTask.Delay(TimeSpan.FromSeconds(0.04f));
            lightGameObject.SetActive(true);
            Juicer.Instance.ReleaseEffect(this);
        }
    }
}