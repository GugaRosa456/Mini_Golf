using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    [Header("UI")]
    public TMP_Text textTacadas;
    public TMP_Text textPar;
    public TMP_Text textRecorde;
    public TMP_Text textResultadoFinal;

    [Header("Pontuação")]
    public int tacadas;
    public int par;
    private int recorde;

    void Awake()
    {
        if (gm == null)
            gm = this;
    }

    void Start()
    {
        tacadas = 0;

        // Define par por fase
        string cenaAtual = SceneManager.GetActiveScene().name;
        if (cenaAtual == "Fase1") par = 3;
        else if (cenaAtual == "Fase2") par = 4;
        else par = 5;

        // Carrega recorde salvo
        recorde = PlayerPrefs.GetInt("Recorde_" + cenaAtual, int.MaxValue);

        // Atualiza UI inicial
        AtualizarUI();

        // 🔥 Limpa o placar final ao iniciar a fase
        if (textResultadoFinal != null)
            textResultadoFinal.text = "";
    }

    public void tacada()
    {
        tacadas++;
        AtualizarUI();
    }

    private void AtualizarUI()
    {
        if (textTacadas != null) textTacadas.text = "Tacadas: " + tacadas;
        if (textPar != null) textPar.text = "Par: " + par;
        if (textRecorde != null)
        {
            textRecorde.text = (recorde == int.MaxValue) ? "Recorde: -" : "Recorde: " + recorde;
        }
    }

    public void FinalizarFase()
    {
        int diferenca = tacadas - par;
        string resultado = CalcularResultadoGolf(diferenca);

        if (textResultadoFinal != null)
        {
            textResultadoFinal.text =
                "Recorde Final!\n" +
                "Resultado: " + resultado + "\n" +
                "Tacadas: " + tacadas + " | Par: " + par;
        }

        // Atualiza recorde se for melhor
        string cenaAtual = SceneManager.GetActiveScene().name;
        if (tacadas < recorde)
        {
            recorde = tacadas;
            PlayerPrefs.SetInt("Recorde_" + cenaAtual, recorde);
            PlayerPrefs.Save();
        }

        AtualizarUI();
    }

    private string CalcularResultadoGolf(int diferenca)
    {
        if (diferenca <= -3) return "Albatross";
        if (diferenca == -2) return "Eagle";
        if (diferenca == -1) return "Birdie";
        if (diferenca == 0) return "Par";
        if (diferenca == 1) return "Bogey";
        if (diferenca == 2) return "Double Bogey";
        return "Over Par";
    }
}
