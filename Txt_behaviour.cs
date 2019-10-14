using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Txt_behaviour : MonoBehaviour
{

    public GameObject txtThere;
    public GameObject txtYou;
    public GameObject txtAre;

    private Graphic fade1;
    private Graphic fade2;
    private Graphic fade3;


    private void Start()
    {
        
        fade1 = txtThere.GetComponent<Graphic>();
        fade2 = txtYou.GetComponent<Graphic>();
        fade3 = txtAre.GetComponent<Graphic>();
        fade1.color = new Color32(28, 198, 204, 0);
        fade2.color = new Color32(28, 198, 204, 0);
        fade3.color = new Color32(28, 198, 204, 0);
        txtThere.SetActive(true);
        txtAre.SetActive(true);
        txtYou.SetActive(true);

    }

    void Update()
    {
    
        fade1.color += new Color32(0, 0, 0, 8);
        fade2.color += new Color32(0, 0, 0, 8);
        fade3.color += new Color32(0, 0, 0, 8);

    }
}
