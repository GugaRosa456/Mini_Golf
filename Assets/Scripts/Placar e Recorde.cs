using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    [Header("UI")]
    public TMP_Text tacadasText;
    public TMP_Text recordeText;
    public TMP_Text resultadoFinalText;

    public GameObject painelFinal;

    private int tacadas = 0;
    private int recorde;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        // Se não existir recorde, começa com um valor muito alto
        recorde = PlayerPrefs.GetInt("RecordeGlobal", 999);

        AtualizarUI();

        if (painelFinal != null)
            painelFinal.SetActive(false);
    }

    void AtualizarUI()
    {
        if (tacadasText != null)
            tacadasText.text = "Tacadas: " + tacadas;

        if (recordeText != null)
            recordeText.text = (recorde == 999) ? "Recorde: -" : "Recorde: " + recorde;
    }

    public void AddTacada()
    {
        tacadas++;
        AtualizarUI();
    }

    // Usado para o professor chamar no código dele
    public void AdicionarPonto()
    {
        AddTacada();
    }

    public void FinalizarFase()
    {
        string nomeCenaAtual = SceneManager.GetActiveScene().name;
        bool ultimaFase = nomeCenaAtual == "Fase6";

        if (!ultimaFase)
            return;

        // ativa painel final
        if (painelFinal != null)
            painelFinal.SetActive(true);

        // coloca resultado (só tacadas)
        if (resultadoFinalText != null)
            resultadoFinalText.text = $"TACADAS: {tacadas}";

        // atualiza recorde
        if (tacadas < recorde)
        {
            recorde = tacadas;
            PlayerPrefs.SetInt("RecordeGlobal", recorde);
            PlayerPrefs.Save();
        }
    }
}
