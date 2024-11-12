using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaserController : MonoBehaviour
{
    public Canvas deathCanvas, gameCanvas;
    public float speed = 5f, rotationSpeed, daraltmaAçýsý = 15f;
    public Vector3 direction;
    public Transform saðKenar, solKenar, altKenar, kareAltKenar, kareÜstKenar, kareSaðKenar, kareSolKenar, çubukSaðKenar, çubukSolKenar;
    public static bool canvasBool = false;
    public GameObject star1, star2, star3, star4, star5, star6, star7, star8, star9, star10, star11, star12, star13, star14, star15;

    private void Start()
    {
        ActivateStar(ref MenuManager.level1b, star1);
        ActivateStar(ref MenuManager.level2b, star2);
        ActivateStar(ref MenuManager.level3b, star3);
        ActivateStar(ref MenuManager.level4b, star4);
        ActivateStar(ref MenuManager.level5b, star5);
        ActivateStar(ref MenuManager.level6b, star6);
        ActivateStar(ref MenuManager.level7b, star7);
        ActivateStar(ref MenuManager.level8b, star8);
        ActivateStar(ref MenuManager.level9b, star9);
        ActivateStar(ref MenuManager.level10b, star10);
        ActivateStar(ref MenuManager.level11b, star11);
        ActivateStar(ref MenuManager.level12b, star12);
        ActivateStar(ref MenuManager.level13b, star13);
        ActivateStar(ref MenuManager.level14b, star14);
        ActivateStar(ref MenuManager.level15b, star15);
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
        else if (other.CompareTag("Level1_Star"))
        {
            int currentLevel = PlayerPrefs.GetInt("CurrentLevel", 0);
            currentLevel += 1;
            PlayerPrefs.SetInt("CurrentLevel", currentLevel);

            for (int i = 2; i <= 15; i++)
            {
                if (PlayerPrefs.GetInt("CurrentLevel") <= i - 1)
                {
                    PlayerPrefs.SetInt("Level" + i, 1);
                    Debug.Log(i);
                    break;
                }
            }
            canvasBool = true;
            SceneManager.LoadScene(0);
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

    public void Play()
    {
        direction = transform.up;
        gameCanvas.gameObject.SetActive(false);
    }

    void ActivateStar(ref bool levelCheck, GameObject star)
    {
        if (levelCheck)
        {
            star.SetActive(true);
        }
    }
}
