using UnityEngine;

public class Speaker_RecordPlayer : MonoBehaviour
{
    [Header("Dönüş Hızı Ayarı")]
    public float donmeHizi = 100f; // Plağın dönüş hızı (33'lük veya 45'lik plaklar için idealdir)

    [Header("Dönüş Ekseni Seçimi")]
    public bool yEksenindeDon = true; // Genelde plaklar Y ekseninde (yukarı-aşağı doğrultuda) döner
    public bool zEksenindeDon = false; // Modelinizin tasarımına göre Z ekseni gerekebilir

    private AudioSource audioSource;

    void Start()
    {
        // Aynı nesne üzerindeki Audio Source bileşenine otomatik ulaşır
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // 1. Kontrol: Eğer bir Audio Source eklendiyse ve Müzik ÇALIYORSA dön
        // 2. Kontrol: Eğer Audio Source yoksa (manuel test için) direkt dön
        if (audioSource == null || audioSource.isPlaying)
        {
            DondurmeIslemi();
        }
    }

    void DondurmeIslemi()
    {
        // Dönüşün tüm bilgisayarlarda aynı hızda olması için Time.deltaTime ile çarpıyoruz
        float donusMiktari = donmeHizi * Time.deltaTime;

        if (yEksenindeDon)
        {
            // Nesneyi Y ekseni etrafında döndürür (Dünyaya göre tam yukarı bakan eksen)
            transform.Rotate(Vector3.up * donusMiktari, Space.Self);
        }
        else if (zEksenindeDon)
        {
            // Nesneyi Z ekseni etrafında döndürür (İleri-geri bakan eksen)
            transform.Rotate(Vector3.forward * donusMiktari, Space.Self);
        }
    }
}
