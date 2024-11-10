using System.Collections;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    public Canvas deathCanvas;
    public float speed = 5f;
    public float rotationSpeed;
    public Vector3 direction;
    public Transform saðKenar;
    public Transform solKenar;
    public Transform altKenar;
    public Transform kareAltKenar;
    public Transform kareÜstKenar;
    public Transform kareSaðKenar;
    public Transform kareSolKenar;
    public Transform çubukSaðKenar;
    public Transform çubukSolKenar;
    public float daraltmaAçýsý = 15f;

    public void Play()
    {
        direction = transform.up;
    }

    void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        transform.position += direction * speed * Time.deltaTime; // Lazerin hareketini saðlýyoruz.
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Vector3 exitPosition = Vector3.zero;
        Vector3 exitDirection = Vector3.zero;

        if (other.CompareTag("AltKenar"))
        {
            exitPosition = saðKenar.position; // hangi kenardan çýkacaðýný belirliyoruz.
            exitDirection = (saðKenar.position - altKenar.position).normalized; // çýkýþ açýsýný belirliyoruz.
            StartCoroutine(KenarDevreDisiBirak(saðKenar.gameObject)); // döngü oluþmamasý için çýkýþ kenarýný anlýk kapatýyoruz.
        }
        else if (other.CompareTag("SaðKenar"))
        {
            exitPosition = solKenar.position;
            exitDirection = (solKenar.position - saðKenar.position).normalized;
            StartCoroutine(KenarDevreDisiBirak(solKenar.gameObject));
        }
        else if (other.CompareTag("SolKenar"))
        {
            exitPosition = altKenar.position;
            exitDirection = (altKenar.position - solKenar.position).normalized;
            StartCoroutine(KenarDevreDisiBirak(altKenar.gameObject));
        }
        else if (other.CompareTag("KareAltKenar"))
        {
            exitPosition = kareSaðKenar.position;
            exitDirection = (kareSaðKenar.position - kareAltKenar.position).normalized;
            StartCoroutine(KenarDevreDisiBirak(kareSaðKenar.gameObject));
        }
        else if (other.CompareTag("KareSaðKenar"))
        {
            exitPosition = kareAltKenar.position;
            exitDirection = (kareAltKenar.position - kareSaðKenar.position).normalized;
            StartCoroutine(KenarDevreDisiBirak(kareAltKenar.gameObject));
        }
        else if (other.CompareTag("KareÜstKenar"))
        {
            exitPosition = kareAltKenar.position;
            exitDirection = (kareAltKenar.position - kareÜstKenar.position).normalized;
            StartCoroutine(KenarDevreDisiBirak(kareAltKenar.gameObject));
        }
        else if (other.CompareTag("KareSolKenar"))
        {
            exitPosition = kareÜstKenar.position;
            exitDirection = (kareÜstKenar.position - kareSolKenar.position).normalized;
            StartCoroutine(KenarDevreDisiBirak(kareÜstKenar.gameObject));
        }
        else if (other.CompareTag("ÇubukSolKenar"))
        {
            exitPosition = çubukSolKenar.position;
            exitDirection = (this.transform.position - çubukSolKenar.position).normalized;
            StartCoroutine(KenarDevreDisiBirak(çubukSolKenar.gameObject));
            StartCoroutine(KenarDevreDisiBirak(çubukSaðKenar.gameObject));
        }
        else if (other.CompareTag("ÇubukSaðKenar"))
        {
            exitPosition = çubukSaðKenar.position;
            exitDirection = (this.transform.position - çubukSaðKenar.position).normalized;
            StartCoroutine(KenarDevreDisiBirak(çubukSolKenar.gameObject));
            StartCoroutine(KenarDevreDisiBirak(çubukSaðKenar.gameObject));
        }
        else if (other.CompareTag("Border"))
        {
            deathCanvas.gameObject.SetActive(true);
        }
        // Çýkýþ açýsýný kýsmi olarak deðiþtiriyoruz.
        if (exitPosition != Vector3.zero)
        {
            transform.position = exitPosition;
            direction = DaraltýlmýþYön(exitDirection, daraltmaAçýsý);
        }
    }

    // Çýkýþ açýsýndaki kýsmi deðiþimi yapýyoruz.
    private Vector3 DaraltýlmýþYön(Vector3 yön, float daraltmaAçýsý)
    {
        float rastgeleAçý = Random.Range(-daraltmaAçýsý, daraltmaAçýsý); // Daraltma açýsý aralýðýnda rastgele bir açý seçiyoruz.
        Quaternion açýDönüþü = Quaternion.Euler(0, 0, rastgeleAçý); // Dönüþ açýsýný belirliyoruz.
        return açýDönüþü * yön;
    }

    private IEnumerator KenarDevreDisiBirak(GameObject kenar)
    {
        kenar.SetActive(false);
        yield return new WaitForSeconds(1f);
        kenar.SetActive(true);
    }
}
