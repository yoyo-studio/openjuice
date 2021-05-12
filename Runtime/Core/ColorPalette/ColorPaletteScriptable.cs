// Copyright (c) 2020 Omid Saadat (@omid3098)

using System.Collections.Generic;
using UnityEngine;

#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#elif NAUGHTY_ATTRIBUTES
using NaughtyAttributes;
#endif

namespace YoYoStudio.OpenJuice
{
    [CreateAssetMenu(menuName = "OpenJuice/Coloring/ColorPalette")]
    public class ColorPaletteScriptable : ScriptableObject
    {
#if NAUGHTY_ATTRIBUTES && !ODIN_INSPECTOR
        [ReorderableList]
#endif
        public List<ColorPair> colors;
#if ODIN_INSPECTOR || NAUGHTY_ATTRIBUTES
        [Button("Set As Current")]
#endif
        public void SetCurrent()
        {
            ColorPalette.SetCurrentPalette(this);
            ColorPalette.UpdateSceneColors();
        }
    }
}