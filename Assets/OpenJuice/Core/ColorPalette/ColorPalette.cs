// Copyright (c) 2020 Omid Saadat (@omid3098)

using UnityEngine;

namespace OpenJuice
{
    public class ColorPalette
    {
        public static ColorPaletteScriptable currentColorPalette { get; private set; }
        public static void SetCurrentPalette(ColorPaletteScriptable colorPaletteScriptable) => currentColorPalette = colorPaletteScriptable;
        public static void UpdateSceneColors()
        {
            var allColorBehaviours = Object.FindObjectsOfType<BaseColorBehaviour>();
            foreach (var item in allColorBehaviours)
            {
                item.UpdateColor();
            }
        }
    }
}