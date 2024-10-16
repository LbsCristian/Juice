using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ComboText : MonoBehaviour
{
    // Start is called before the first frame update
    GameManager gm;
    TextMeshProUGUI text;
    Animation an;
    void Start()
    {
        gm = FindAnyObjectByType<GameManager>();
        text = GetComponent<TextMeshProUGUI>();
        

    }

    // Update is called once per frame
    void Update()
    {
        text.text = gm.Combo.ToString();
        
    }

}
