using System.Collections;
using System.Collections.Generic;
using OpenJuice;
using UnityEngine;

public class LoadSceneButton : BaseButton
{
    [SerializeField] string sceneName;
    protected override void OnPressed()
    {
        Juicer.Instance.LoadScene(sceneName);
    }
}
