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
        //LoadSceneAsync vai carregar de forma ass�ncrona a pr�xima sena, com tudo da atual em uso;
        //armazeno em uma vari�vel opera��o pra usar as propriedades;
        AsyncOperation operation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneIndex);

        //ativando tela quando a fun��o for chamada no OnClick();
        _loadingScreen.SetActive(true);

        //enquanto operation n�o tiver finalizado...
        while (!operation.isDone)
        {
            //"reparametrizando" o operation.progress que s� vai de 0 at� 0.9;
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            _slider.value = progress;

            //aguardar at� o pr�ximo frame - n�o um tempo espec�fico
            yield return null;
        }
    }

    public void QuitInterface()
    {
        Application.Quit();
    }
}
