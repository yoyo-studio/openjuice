# OpenJuice

OpenJuice tries to cover methods to juice up your unity games.

## Features:

## 1- Color

![image](https://git.cafebazaar.ir/cafebazi-studio/openjuice/uploads/8b87aac7a6fa0d6c9c71f6492456c561/OpenJuice_Color.gif)

Helps you to change the whole scene color in edit mode or runtime.
OpenJuice comes with 3 color palettes to use. You also can make your own color palettes from [Adobe Colors](https://color.adobe.com/create/color-wheel) or [Coolors](https://coolors.co/palettes/popular) or read [this tutorial](https://gamedevelopment.tutsplus.com/articles/picking-a-color-palette-for-your-games-artwork--gamedev-1174) to get more information about this topic.

### Usage:

1- Create a `ColorPaletteScriptable` Object or use pre-made ones. and fill it with some colorName objects and colors pairs. (you can use premade colorNameObjects or create new ones from `"OpenJuice/Coloring/ColorNameObject"` in create asset menu)

2- Do NOT manually set color On your images, texts, renderers, or cameras. Instead use `[Whatever]ColorBehaviour` components on them and set the ColorNameObject field. i.e. `ImageColorBehaviour` for Image.

3- Select your `ColorPaletteScriptable` and click on `SetAsCurrent` button.

Note: this will only change colors for current scene openned only. if you have multiple scenes, you need to open them as well and press SetAsCurrent button on your ColorPaletteScriptable again.

You can also check `01_ColorPaletteExampleScene` scene to test pre-made color palettes.

## BokehEditor

![image](https://git.cafebazaar.ir/cafebazi-studio/openjuice/uploads/5f90b03a8a89a84549c5b96126257a70/OpenJuice_BokehEditor.gif)

### Usage

1- Prepare a static blured image.

2- Add BokehEditor component to an empty game object.

3- Assign material and sprite to use for bokeh and set flicker and movement chance.

4- Press Play and click on your scene. this will instantiate bokeh instances and **You can change all bokeh sizes with mouse scroll**

5- Press StopEditing, manually change instances component parameters if needed and Bake to prefab. it will make a prefab in bokeh sprite path.

![OpenJuice_BokehEditor_WIP](https://git.cafebazaar.ir/cafebazi-studio/openjuice/uploads/b748d9820fb6349df83c60a5f8ffafc9/OpenJuice_BokehEditor_WIP.gif)

## 2- Tweening

This repo uses [DoTween](http://dotween.demigiant.com/inde) library to tween different things.
These effects are supported:

## Move Transition:

Simply Add MoveTransition component to your GameObjects and config your desired values.

![MoveTransitions](https://git.cafebazaar.ir/omid.saadat/openjuice/uploads/a8d4ff0a1d6a902bebeabd43568f9fa8/MoveTransitions.gif)

- Moving things:
  - Move objects with tweens.
  - Stretch in move direction.
  - Rotate in move direction.
  - Trail or particle
- Hitted things:
  - Change scale
  - Wobble
  - Change color
  - Shake or scale some things
  - Play sound on each hit
  - Play some particles
  - Push things need to destroy, scale them down or shatter them
- Music
- Particles
- Slow motion/Fast speed
- Camera Shake
- Camera Zoom
- Flash
- Personalize things (like by adding eyes and mouth to them)
- Bloom

External Links: [Juice it or loose it](https://www.youtube.com/watch?v=Fy0aCDmgnxg)
