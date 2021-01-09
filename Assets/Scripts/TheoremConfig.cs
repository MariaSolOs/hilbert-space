using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Scriptable Objects/Theorem Configuration")]
public class TheoremConfig : ScriptableObject
{
    [SerializeField] Image theoremImage = default;
    [SerializeField] GameObject[] theoremSymbols = default;

    public Image GetTheoremImage()
    {
        return theoremImage;
    }

    public GameObject[] GetTheoremSymbols()
    {
        return theoremSymbols;
    }
}
