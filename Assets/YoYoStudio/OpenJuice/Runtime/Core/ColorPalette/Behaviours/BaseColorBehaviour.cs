// Copyright (c) 2020 Omid Saadat (@omid3098)

using UnityEngine;

#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#elif NAUGHTY_ATTRIBUTES
using NaughtyAttributes;
#endif

namespace YoYoStudio.OpenJuice
{
    public abstract class BaseColorBehaviour : MonoBehaviour, IColorBehaviour
    {
        [SerializeField] protected ColorNameObject colorNameObject;
        public abstract void UpdateColor();
        
#if ODIN_INSPECTOR || NAUGHTY_ATTRIBUTES
        [Button("Apply Color")]
#endif
        public void ApplyColors()
        {
            if (ColorPalette.CurrentColorPalette != null)
                ColorPalette.UpdateSceneColors();
            else
                Debug.LogWarning("Please select a color palette first");
        }
    }
}