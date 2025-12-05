using UnityEngine;
using UnityEngine.SceneManagement;

public class PontoInicial : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Reinicia a cena quando encostar em um trigger
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
