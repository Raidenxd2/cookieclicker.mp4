using System.Collections;
using System.Collections.Generic;
using HSVPicker;
using UnityEngine;

public class BGColor : MonoBehaviour
{

    public new Renderer renderer;
    public ColorPicker picker;

    public Color Color = Color.blue;
    public bool SetColorOnStart = false;

	// Use this for initialization
	void Start () 
    {
        picker.onValueChanged.AddListener(color =>
        {
            renderer.material.color = color;
            Color = color;
        });

		renderer.material.color = picker.CurrentColor;
        if(SetColorOnStart) 
        {
            picker.CurrentColor = Color;
        }
        }

    // Update is called once per frame
    void Update()
    {
        
    }
}
