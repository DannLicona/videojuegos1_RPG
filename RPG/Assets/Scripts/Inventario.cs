using UnityEngine;
using UnityEngine.UI;

public class Inventario : MonoBehaviour
{
    private bool muestraInventario;
    public GameObject goInventario;
    [SerializeField] private string[] valoresInventario;
    private int numc1, numc2, numc3, numc4, numc9, numc10, numc11, numc12, numc16;
    Button boton;
    public Sprite c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15, c16, contenedor;

    void Start()
    {
        muestraInventario = false;
        BorraArreglo();
        numc1 = 0;
        numc2 = 0;
        numc3 = 0;
        numc4 = 0;
        numc9 = 0;
        numc10 = 0;
        numc11 = 0;
        numc12 = 0;
        numc16 = 0;
    }

    public void StatusInventario()
    {
        if (muestraInventario)
        {
            muestraInventario = false;
            goInventario.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            muestraInventario = true;
            goInventario.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void EscribeEnArreglo()
    {
        if (VerificaEnArreglo() == -1)
        { //No está en el inventario
            for (int i = 0; i < valoresInventario.Length; i++)
            {
                if (valoresInventario[i] == "")
                { //Lo coloca en la primera posición vacía que encuentre
                    valoresInventario[i] = Coleccionables.objAColeccionar;
                    DibujaElementos(i);
                    break;
                }
            }
        }
        else
        { //Si ya está en el inventario, ubica su posición y suma uno al elemento
            DibujaElementos(VerificaEnArreglo());
        }
    }

    private int VerificaEnArreglo()
    {
        int pos = -1;
        for (int i = 0; i < valoresInventario.Length; i++)
        {
            if (valoresInventario[i] == Coleccionables.objAColeccionar)
            {
                pos = i;
                break;
            }
        }
        return pos;
    }

    public void DibujaElementos(int pos)
    {
        StatusInventario();
        boton = GameObject.Find("elemento0 (" + pos + ")").GetComponent<Button>();
        switch (Coleccionables.objAColeccionar)
        {
            case "c1":
                numc1++;
                boton.GetComponentInChildren<Text>().text = "x" + numc1.ToString();
                contenedor = c1;
                break;
            case "c2":
                numc2++;
                boton.GetComponentInChildren<Text>().text = "x" + numc2.ToString();
                contenedor = c2;
                break;
            case "c3":
                numc3++;
                boton.GetComponentInChildren<Text>().text = "x" + numc3.ToString();
                contenedor = c3;
                break;
            case "c4":
                numc4++;
                boton.GetComponentInChildren<Text>().text = "x" + numc4.ToString();
                contenedor = c4;
                break;
            case "c5":
                contenedor = c5;
                break;
            case "c6":
                contenedor = c6;
                break;
            case "c7":
                contenedor = c7;
                break;
            case "c8":
                contenedor = c8;
                break;
            case "c9":
                numc9++;
                boton.GetComponentInChildren<Text>().text = "x" + numc9.ToString();
                contenedor = c9;
                break;
            case "c10":
                numc10++;
                boton.GetComponentInChildren<Text>().text = "x" + numc10.ToString();
                contenedor = c10;
                break;
            case "c11":
                numc11++;
                boton.GetComponentInChildren<Text>().text = "x" + numc11.ToString();
                contenedor = c11;
                break;
            case "c12":
                numc12++;
                boton.GetComponentInChildren<Text>().text = "x" + numc12.ToString();
                contenedor = c12;
                break;
            case "c13":
                contenedor = c13;
                break;
            case "c14":
                contenedor = c14;
                break;
            case "c15":
                contenedor = c15;
                break;
            case "c16":
                numc16++;
                boton.GetComponentInChildren<Text>().text = "x" + numc16.ToString();
                contenedor = c16;
                break;
        }
        boton.GetComponent<Image>().sprite = contenedor;
    }

    private void BorraArreglo()
    {
        for (int i = 0; i < valoresInventario.Length; i++)
        {
            valoresInventario[i] = "";
        }
    }
}
