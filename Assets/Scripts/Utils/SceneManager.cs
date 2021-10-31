using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    [SerializeField] private GameObject _loadingScreen;
    [SerializeField] private Slider _slider;

    private void Awake()
    {
        _loadingScreen.SetActive(false);
    }

    //o index de cada cena fica em file>build settings;
    public void LoadScene(int sceneIndex)
    {
        //cena eu atribuo em cada OnClick();
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously (int sceneIndex)
    {
        //LoadSceneAsync vai carregar de forma assíncrona a próxima sena, com tudo da atual em uso;
        //armazeno em uma variável operação pra usar as propriedades;
        AsyncOperation operation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneIndex);

        //ativando tela quando a função for chamada no OnClick();
        _loadingScreen.SetActive(true);

        //enquanto operation não tiver finalizado...
        while (!operation.isDone)
        {
            //"reparametrizando" o operation.progress que só vai de 0 até 0.9;
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            _slider.value = progress;

            //aguardar até o próximo frame - não um tempo específico
            yield return null;
        }
    }

    public void QuitInterface()
    {
        Application.Quit();
    }
}
