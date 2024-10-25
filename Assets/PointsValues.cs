using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsValues : MonoBehaviour
{
    TextMeshPro tmp;
    float pointsValue = 10 * GameManager.Instance.Combo;

    private void Awake()
    {
        tmp = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        tmp.text = "+" + pointsValue.ToString();
    }
}
