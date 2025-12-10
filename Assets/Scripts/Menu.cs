using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [Header("Configurações do Menu")]
    public string nomeDaFase = "Fase1";

    private Canvas canvas;
    private Image fundo;
    private Button botaoJogar;
    private Text textoBotao;

    void Start()
    {
        CriarUI();
    }

    void CriarUI()
    {
        // ------------------------------
        // 1) Criar Canvas
        // ------------------------------
        GameObject canvasObj = new GameObject("CanvasMenu");
        canvas = canvasObj.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvasObj.AddComponent<CanvasScaler>();
        canvasObj.AddComponent<GraphicRaycaster>();

        // ------------------------------
        // 2) Fundo cinza
        // ------------------------------
        GameObject fundoObj = new GameObject("Fundo");
        fundoObj.transform.SetParent(canvasObj.transform);

        fundo = fundoObj.AddComponent<Image>();
        fundo.color = new Color(0.15f, 0.15f, 0.15f, 1f);  // Cinza escuro bonito

        RectTransform fRect = fundo.GetComponent<RectTransform>();
        fRect.anchorMin = Vector2.zero;
        fRect.anchorMax = Vector2.one;
        fRect.offsetMin = Vector2.zero;
        fRect.offsetMax = Vector2.zero;

        // ------------------------------
        // 3) Criar botão
        // ------------------------------
        GameObject botaoObj = new GameObject("BotaoJogar");
        botaoObj.transform.SetParent(canvasObj.transform);

        botaoJogar = botaoObj.AddComponent<Button>();
        Image imgBotao = botaoObj.AddComponent<Image>();
        imgBotao.color = new Color(0.9f, 0.3f, 0.3f); // Vermelho suave

        RectTransform bRect = botaoObj.GetComponent<RectTransform>();
        bRect.sizeDelta = new Vector2(300, 100);
        bRect.anchoredPosition = Vector2.zero;

        // ------------------------------
        // 4) Texto do botão
        // ------------------------------
        GameObject textoObj = new GameObject("TextoBotao");
        textoObj.transform.SetParent(botaoObj.transform);

        textoBotao = textoObj.AddComponent<Text>();
        textoBotao.text = "JOGAR";
        textoBotao.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
        textoBotao.alignment = TextAnchor.MiddleCenter;
        textoBotao.color = Color.white;
        textoBotao.fontSize = 40;

        RectTransform tRect = textoObj.GetComponent<RectTransform>();
        tRect.anchorMin = Vector2.zero;
        tRect.anchorMax = Vector2.one;
        tRect.offsetMin = Vector2.zero;
        tRect.offsetMax = Vector2.zero;

        // Função do botão
        botaoJogar.onClick.AddListener(IniciarFase);
    }

    public void IniciarFase()
    {
        SceneManager.LoadScene(nomeDaFase);
    }
}
