// Copyright (c) 2020 Omid Saadat (@omid3098)

using System.Collections;
using UnityEngine;

namespace OpenJuice
{
    public class LightningEffect : Effect
    {
        [SerializeField] GameObject lightGameObject = null;
        public override void PlayStartEffect()
        {
            base.PlayStartEffect();
            StartCoroutine(StartBlinkEffect());
        }

        private IEnumerator StartBlinkEffect()
        {
            yield return new WaitForSeconds(0.2f);
            lightGameObject.SetActive(false);
            yield return new WaitForSeconds(0.08f);
            lightGameObject.SetActive(true);
            yield return new WaitForSeconds(0.3f);
            lightGameObject.SetActive(false);
            yield return new WaitForSeconds(0.04f);
            lightGameObject.SetActive(true);
            Juicer.Instance.ReleaseEffect(this);
        }
    }
}