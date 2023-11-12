using UnityEngine.UI;
using UnityEngine;

public class SetDash : MonoBehaviour
{
    public Slider slider;
    //Referenca na slider
    public void FillDash(float energy)
    {
        slider.value=energy;
        //Podesavamo slider na primljeni parametar "energy"
    }

    void Start() 
    {
        FillDash(3f);
        //U pocetku bar je napunjen do kraja
    }
}
