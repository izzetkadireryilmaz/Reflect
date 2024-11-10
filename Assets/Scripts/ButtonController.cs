using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public GameObject laser;
    public GameObject laserClone;
    public GameObject triangle;
    public GameObject square;
    public GameObject stick;
    public Canvas DeathCanvas;
    public float rotationSpeed = 45f;
    private bool TriangleRotate = false;
    private bool SquareRotate = false;
    private bool StickRotate = false;

    private void Start()
    {
        laserClone.SetActive(true);
    }
    void Update()
    {
        if (laserClone.activeSelf)
        {
            laser.SetActive(false);
        }
        else
        {
            laser.SetActive(true);
        }

        if (TriangleRotate == true)
        {
            triangle.transform.Rotate(-Vector3.forward * rotationSpeed * Time.deltaTime);
        }
        if (SquareRotate == true)
        {
            square.transform.Rotate(-Vector3.forward * rotationSpeed * Time.deltaTime);
        }
        if (StickRotate == true)
        {
            stick.transform.Rotate(-Vector3.forward * rotationSpeed * Time.deltaTime);
        }
    }
    public void Active()
    {
        laserClone.SetActive(false);
    }
    public void StartTriangleRotation()
    {
        TriangleRotate = true;
    }
    public void StopTriangleRotation()
    {
        TriangleRotate = false;
    }
    public void StartSquareRotation()
    {
        SquareRotate = true;
    }
    public void StopSquareRotation()
    {
        SquareRotate = false;
    }
    public void StartStickRotation()
    {
        StickRotate = true;
    }
    public void StopStickRotation()
    {
        StickRotate = false;
    }

    public void Home()
    {
        SceneManager.LoadScene(0);
    }
    public void Retry()
    {
        DeathCanvas.gameObject.SetActive(false);
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
