using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsSystem : MonoBehaviour
{
    public int points;
    public GameObject pointsText;
    TextMeshProUGUI textComponent;
    // Start is called before the first frame update
    void Start()
    {
        textComponent = pointsText.GetComponent<TextMeshProUGUI>();
        points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        string pointsText = "Points: " + points;
        textComponent.text = pointsText;
    }
}
