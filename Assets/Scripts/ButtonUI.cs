using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonUI : MonoBehaviour
{
    public void MouseEnter()
    {
        LeanTween.scale(gameObject, new Vector3(1.5f, 1.5f, 1.5f), 0.15f).setEaseInOutBounce();
    }

    public void MouseExit()
    {
        LeanTween.scale(gameObject, new Vector3(1f, 1f, 1f), 0.15f);
    }
}
