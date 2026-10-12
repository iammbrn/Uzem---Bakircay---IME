using UnityEngine;

public class BallBounceSound : MonoBehaviour
{
    private AudioSource audioSource;
    public float minVelocityForSound = 0.5f; // Çok hafif sürtünmelerde ses çıkmasını engeller

    void Start()
    {
        // Nesnenin üzerindeki Audio Source bileşenini otomatik bulur
        audioSource = GetComponent<AudioSource>();
    }

    // Top bir yere çarptığı anda bu fonksiyon tetiklenir
    private void OnCollisionEnter(Collision collision)
    {
        // Çarpma hızının şiddetini kontrol et (Yavaşça dururken ses çılgın gibi çalmasın)
        if (collision.relativeVelocity.magnitude > minVelocityForSound)
        {
            // Eğer ses şu an çalmıyorsa veya üst üste binebilsin istiyorsanız PlayOneShot kullanın
            audioSource.PlayOneShot(audioSource.clip);
        }
    }
}
