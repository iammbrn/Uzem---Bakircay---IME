using UnityEngine;
using UnityEngine.InputSystem; 

public class PhotoMachine : MonoBehaviour
{
    [Header("Bileşen Bağlantıları")]
    public Camera fotografKamerasi; 
    
    // Değişiklik: AudioSource yerine AudioClip yaptık, artık direkt ses dosyasını kabul eder!
    public AudioClip deklansorSesi; 

    private AudioSource audioSource; // Arka planda sesi çalmak için kullanacağız
    private bool fotografCekildi = false;

    void Start()
    {
        if (fotografKamerasi != null)
            fotografKamerasi.enabled = true;

        // Nesnede gizli bir ses oynatıcı oluşturur veya var olanı alır
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame && !fotografCekildi)
        {
            FotografCek();
        }
    }

    void FotografCek()
    {
        fotografCekildi = true;

        // Doğrudan sürüklediğiniz ses klibini tek seferlik çalar
        if (deklansorSesi != null && audioSource != null)
        {
            audioSource.PlayOneShot(deklansorSesi);
        }

        if (fotografKamerasi != null)
        {
            fotografKamerasi.enabled = false;
        }

        Debug.Log("Fotoğraf çekildi ve çıktı ekranında donduruldu!");
    }

    public void YeniFotoğrafHazırla()
    {
        fotografCekildi = false;
        if (fotografKamerasi != null)
            fotografKamerasi.enabled = true;
    }
}
