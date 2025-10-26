using UnityEngine;
using UnityEngine.Audio; // ¡Importante para el AudioMixer!
using UnityEngine.UI;     // ¡Importante para Slider y Text!
using TMPro;              // ¡Importante si usas TextMeshPro!
// using UnityEngine.SceneManagement; // Ya no es necesario si el botón regresar lo maneja otro script o está quitado.

public class SettingsMenu : MonoBehaviour
{
    // ------------------ Referencias que arrastrarás desde el Inspector ------------------
    public AudioMixer mainMixer;
    public Slider volumeSlider;
    public TextMeshProUGUI volumePercentageText; // Cambia a 'public Text volumePercentageText;' si no usas TextMeshPro
    public Button muteButton;
    // public Button backButton; // ¡Quitamos la referencia al botón de regresar!

    // ------------------ Variables internas para la lógica ------------------
    private float currentVolumeBeforeMute; // Guarda el volumen antes de mutear
    private bool isMuted = false;

    // ------------------ Métodos de Ciclo de Vida de Unity ------------------
    void Start()
    {
        // 1. Cargar el último volumen guardado y aplicarlo al inicio de la escena
        LoadVolumeSettings();

        // 2. Conectar el método SetVolume al evento de cambio del Slider
        // Esto asegura que SetVolume se llama cada vez que el slider se mueve
        volumeSlider.onValueChanged.AddListener(SetVolume);

        // 3. Conectar el evento click al botón MUTE
        muteButton.onClick.AddListener(ToggleMute);
        // backButton.onClick.AddListener(GoBack); // ¡Quitamos la conexión del botón de regresar!
    }

    // ------------------ Métodos para la Lógica del Volumen ------------------
    private void LoadVolumeSettings()
    {
        // Obtiene el valor del slider guardado (por defecto 1f si no hay nada guardado)
        float savedSliderValue = PlayerPrefs.GetFloat("MasterVolumeValue", 1f);
        
        // Asigna este valor al slider de UI
        volumeSlider.value = savedSliderValue;
        
        // Llama a SetVolume para aplicar este valor al mixer y actualizar el texto de porcentaje
        SetVolume(savedSliderValue); // Esto también actualizará 'currentVolumeBeforeMute'
    }

    public void SetVolume(float sliderValue)
    {
        // Si el slider se mueve a un valor audible y estaba muteado, lo desmuteamos
        if (isMuted && sliderValue > 0.0001f)
        {
            isMuted = false;
            // Si quieres cambiar el texto/imagen del botón Mute, hazlo aquí
            // muteButton.GetComponentInChildren<TextMeshProUGUI>().text = "MUTE"; 
        }

        // Guardamos el valor actual del slider antes de convertirlo a decibelios
        currentVolumeBeforeMute = sliderValue;

        // ¡La magia de los decibelios! Conversión de lineal (slider) a logarítmica (mixer)
        float volumeInDB = Mathf.Log10(sliderValue) * 20;
        
        // Aplica el volumen al parámetro "MasterVolume" que expusimos en el Audio Mixer
        mainMixer.SetFloat("MasterVolume", volumeInDB);
        
        // Guarda el valor del slider (no el valor en dB) para la próxima vez que el juego inicie
        PlayerPrefs.SetFloat("MasterVolumeValue", sliderValue);

        // Actualiza el texto de porcentaje en la UI
        UpdateVolumePercentageText(sliderValue);
    }

    private void UpdateVolumePercentageText(float sliderValue)
    {
        // Calcula el porcentaje y lo muestra en el texto de tu UI
        int percentage = Mathf.RoundToInt(sliderValue * 100);
        volumePercentageText.text = percentage.ToString() + "%";
    }

    public void ToggleMute()
    {
        isMuted = !isMuted; // Invierte el estado de mute (de true a false o viceversa)

        if (isMuted)
        {
            // Guarda el volumen actual del slider ANTES de mutear si no lo hemos hecho ya
            // Esto es por si el usuario mutéa con el slider en un valor alto
            if (currentVolumeBeforeMute < 0.0001f) // Si el slider ya estaba al mínimo (silencio)
            {
                // Intentamos recuperar un volumen previo, o usamos 1f por seguridad
                currentVolumeBeforeMute = PlayerPrefs.GetFloat("MasterVolumeValue", 1f);
                if (currentVolumeBeforeMute < 0.0001f) currentVolumeBeforeMute = 1f; // Evitar que se guarde 0
            }

            // Aplica silencio casi total al mixer (-80dB es inaudible)
            mainMixer.SetFloat("MasterVolume", -80f);
            // Mueve el slider de UI a su posición mínima para reflejar el mute
            volumeSlider.value = 0.0001f; 
            UpdateVolumePercentageText(0.0001f); // Muestra 0%
        }
        else // Si no está muteado (es decir, queremos desmutear)
        {
            // Restaura el valor del slider a donde estaba antes de mutear
            volumeSlider.value = currentVolumeBeforeMute;
            // Llama a SetVolume para aplicar este volumen al mixer y actualizar el texto
            SetVolume(currentVolumeBeforeMute);
        }
        // Opcional: Si tu botón "MUTE" cambia de texto (ej. "MUTE" a "UNMUTE") o de imagen, actualízalo aquí
        // muteButton.GetComponentInChildren<TextMeshProUGUI>().text = isMuted ? "UNMUTE" : "MUTE";
    }

    // public void GoBack() // ¡Quitamos el método GoBack completo!
    // {
    //     Debug.Log("Volviendo a la escena anterior o al menú principal.");
    // }
}