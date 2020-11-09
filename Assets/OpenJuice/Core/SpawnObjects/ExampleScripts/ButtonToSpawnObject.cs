// Copyright (c) 2020 Omid Saadat (@omid3098)
using UnityEngine;
namespace OpenJuice
{
    public class ButtonToSpawnObject : BaseButton
    {
        [SerializeField] string effectID;
        protected override void OnPressed()
        {
            Effect effect = Juicer.Instance.PlayEffect(effectID);
        }
    }
}