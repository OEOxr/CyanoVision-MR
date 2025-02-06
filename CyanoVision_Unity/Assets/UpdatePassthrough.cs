using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpdatePassthrough : MonoBehaviour
{
    public bool OverrideStat = false;
    public OVRPassthroughLayer layer;
    public float aBrightness;
    public float sBrightness;
    public float aContrast;
    public float aSaturation;
    public OVRPassthroughLayer.ColorMapEditorType colormap;
    public Gradient agradient;
    public List<Color> colors;
    public float colorx;
    public float colorS;

    private GradientColorKey[] colorKeys;
    public bool MakeDarkerIND = false;
    public GameObject MakeDarkerINDBTN;

    public TMPro.TMP_Text StatusText;


    // Start is called before the first frame update
    void Start()
    {
    }   

    private void Update()
    {
        if (MakeDarkerINDBTN.GetComponent<Toggle>())
        {
            MakeDarkerINDBTN.GetComponent<Toggle>().enabled = MakeDarkerIND;
            MakeDarkerINDBTN.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(3).GetComponent<TMPro.TMP_Text>().text = MakeDarkerIND.ToString();
        }


    }

    public void EnableOverride(bool s)
    {
        OverrideStat = s;
        UpdateLayer();
    }




    [ContextMenu("UpdateLayer")]
    // Update is called once per frame
    public void UpdateLayer()
    {
        
        if (OverrideStat && layer != null)
        {
            layer.SetColorMapControls(aBrightness, aContrast, aSaturation,agradient);
            //layer.SetBrightnessContrastSaturation(aBrightness, aContrast, aSaturation);
        }

        StartCoroutine(RandomUpdateRoutine());
    }

    [ContextMenu("RandomROutine")]
    private IEnumerator RandomUpdateRoutine()
    {

        float waitTime = Random.Range(8, 35);
        print("inside Random and waitTime : " + waitTime);
        if (StatusText != null)
            StatusText.text = waitTime.ToString();

        yield return new WaitForSeconds(waitTime);

        Debug.Log("afterwait time");
        if(MakeDarkerIND == false)
            StartCoroutine(MakeDarker());
    }

    private IEnumerator MakeDarker()
    {
        MakeDarkerIND = true;
        print("inside Makedarker");
        //UpdateLayer();
        colorS = colorx;
        updateGradient(colorx+0.8f);


        yield return new WaitForSeconds(10);
            MakeNormal();

    }

    private void MakeNormal()
    {
        print("inside makenormal");
        updateGradient(colorS);
        MakeDarkerIND = false;

    }





    public void ContrastUp(float x)
    {
            aContrast = x;
             UpdateLayer();
    }
    public void BrighnessUp(float x)
    {
        aBrightness=sBrightness=x;
        UpdateLayer();
    }
    public void SaturationUp(float x)
    {
        aSaturation= x;
        UpdateLayer();
    }

    public void updateGradient(float x)
    {
        colorx = x;
        colorKeys = agradient.colorKeys;

        //Color currentColor; //= colorKeys[1].color;
        colorKeys[1].color = Color.Lerp(colors[0], colors[1], x);
        
        agradient.SetKeys(colorKeys,agradient.alphaKeys);

        UpdateLayer();



    }

}
