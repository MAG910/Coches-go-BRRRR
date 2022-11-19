using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Esta clase implementa el método de Euler para el cálculo de ecuanciones diferenciales de segundo orden
//Usos: Smoothear la respuesta de una variable ante cambios súbitos
//Referencia: https://www.youtube.com/watch?v=KPoeNZZ6H4s
//Nota, este modelo asume que el modelo es unidimensional. Para modelos multidimensionales cambiar xp, y, yd, x0, x y xd por vectores

public class SecondOrderDynamics1D : MonoBehaviour
{
    

    public static (float, float) EulerMethodStep(float y, float yd, float f, float z, float r, float x0,float T, float x, float xd = float.NaN) 
    {

        //Compute constants
        float k1 = z / (Mathf.PI * f);
        float k2 = 1 / ((2 * Mathf.PI * f) * (2 * Mathf.PI * f));
        float k3 = r * z / (2 * Mathf.PI * f);

        //Initialize variables
        float xp = x0;
        

        if (xd == float.NaN)
        {
            xd = (x - xp) / T;
            xp = x;
        }

        //Euler's method
        y = y + T * yd;
        yd = yd + T * (x + k3 * xd - y - k1 * yd) / k2;
        return (y, yd);
    
    }

        



}
