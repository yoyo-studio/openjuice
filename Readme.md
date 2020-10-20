# OpenJuice

Based on [Juice it or loose it](https://www.youtube.com/watch?v=Fy0aCDmgnxg) talk and some other references, this repo tries to cover methods to juice up your unity games.

## Features:

## 1- Color

![image](https://git.cafebazaar.ir/omid.saadat/openjuice/uploads/982cd0b01ead0d7971f793a9521f0fa7/image.png)

Make sure your things have fun colors!
This repository provides some color palettes to use.
You also can make your own color palettes from [Adobe Colors](https://color.adobe.com/create/color-wheel) or [Coolors](https://coolors.co/palettes/popular) or read [this tutorial](https://gamedevelopment.tutsplus.com/articles/picking-a-color-palette-for-your-games-artwork--gamedev-1174) to get more information about this topic.

### Usage:

1- Create a ColorPaletteScriptable Object or use pre-made ones. and fill it with some colorName objects and colors pairs. (you can use premade colorNameObjects or create new ones from "OpenJuice/Coloring/ColorNameObject" in create asset menu)

2- On your images, texts, renderers, or cameras do not set color manually. Instead use [Whatever]ColorBehaviour components on them and set the ColorNameObject field. i.e. ImageColorBehaviour for setting desired image.

3- Select your ColorPaletteScriptable and click on SetAsCurrent button.

Note: this will only change colors for current scene openned only. if you have multiple scenes, you need to open them as well and press SetAsCurrent button on your ColorPaletteScriptable again.

You can also check `01_ColorPaletteExampleScene` scene to test pre-made color palettes.

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
