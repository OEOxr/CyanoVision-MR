using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;
using UnityEngine.UI;

public class SliderHandler : MonoBehaviour
{
    public float SliderValue = 0;
    public float MinValue = 0;
    public float MaxValue = 1;
    public bool WholeNumbers = false;


    public string Label = "The Label";
    public string LeftHandLabel = "Low";
    public string RightHandLabel = "High";

    public TMP_Text Labelobj;
    public TMP_Text LHLabelobj;
    public TMP_Text RHLabelobj;

    public UnityEngine.UI.Slider theslider;

    // Start is called before the first frame update
    void Start()
    {
        theslider.wholeNumbers = WholeNumbers;
        theslider.minValue = MinValue;
        theslider.maxValue = MaxValue;
        theslider.value = SliderValue;

        Labelobj.text = Label +" : "+SliderValue;
        LHLabelobj.text = LeftHandLabel;
        RHLabelobj.text = RightHandLabel;
        theslider.value = SliderValue;

    }

    // Update is called once per frame
    public void UpdateLabel(float x)
    {
        Labelobj.text = Label + " : " + x;

    }




}
