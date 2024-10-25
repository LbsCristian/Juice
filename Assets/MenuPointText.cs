using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuPointText : MonoBehaviour
{
    TextMeshProUGUI text;
    // Start is called before the first frame update
    void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance != null)
        {
            print("wow");
            text.text = GameManager.Instance.points.ToString();
        }
    }
}
