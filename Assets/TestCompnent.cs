using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCompnent : MonoBehaviour
{   
    //bool current = false;
    int material_index = 1;
    //int localScale_index = 1;
    public Material color1;
    public Material color2;

    // Start is called before the first frame update
    void Start()
    {
        this.material_index = PlayerPrefs.GetInt("cube.material",1);
        this.UpdateMaterial();

        /*this.localScale_index = PlayerPrefs.GetInt("cube.Scale",1);
        this.UpdateLocalScale();
        */
    }

    // Update is called once per frame
    void Update()
    {
        //Transform
        transform.Rotate (5000f, 5000f, 5000f);
        transform.Translate (0.001f, 0.001f, 0.001f);
        transform.localScale = transform.localScale * 1.0003f;

        //Color changing Automatically
        var renderer = this.GetComponent<MeshRenderer>();
        var color = renderer.material.color;
        color.r += Time.deltaTime / 4.0f;
        renderer.material.color = color;
        
    }

    private void UpdateMaterial(){
        var renderer = this.GetComponent<MeshRenderer>();
        //update the Cube Material
        if (this.material_index == 1){
        renderer.material = this.color1;
        } 
        else{
            renderer.material = this.color2;
        }
    }

    //save scale
    /*private void UpdateLocalScale(){
        //update the Cube Scale
        if (this.localScale_index == 1){
        transform.localScale = transform.localScale * 1.0003f;
        } 
        else{
            transform.localScale = transform.localScale * 1f;
        }
    }*/

    //Button1 to increse the size of the cube
    public void ButtonWasClicked(){
        var transform = this.GetComponent<Transform>();
        //transform.position = new Vector3(0.1f, 0.1f, 0.1f);
        transform.localScale = transform.localScale * 1.5f;

        //save scale after hit the button
        /*this.localScale_index += 1;
        if (this.localScale_index > 2) {
            this.localScale_index = 1;
        }
        this.UpdateLocalScale();
        this.Save();
        */

    }

    //Button2 to decrese the size of the cube
    public void ButtonWasClicked2(){
        var transform = this.GetComponent<Transform>();
        transform.localScale = transform.localScale * 0.5f;

    }

    //Button3 is to change the color of the cube
    public void ButtonWasClicked3(){
        var renderer = this.GetComponent<MeshRenderer>();
        /*
        if (this.current) {
            renderer.material = this.color2;
        }   else{
            renderer.material = this.color1;
        }
            this.current = !this.current;
        */
        this.material_index += 1;
        if (this.material_index > 2) {
            this.material_index = 1;
        }
        this.UpdateMaterial();
        this.Save();
    }

    //Button4 is to set the cube to the original spot
    public void ButtonWasClicked4(){
        var transform = this.GetComponent<Transform>();
        transform.position = new Vector3(0, -5, 0);
    }

    public void Save(){
        PlayerPrefs.SetInt("cube.material",this.material_index);
        //PlayerPrefs.SetInt("cube.Scale",this.localScale_index);

    }
}
