using UnityEngine;
using UnityEngine.UI;

public class MainCamera : MonoBehaviour
{
    //objetos vazios das posi��es
    public Transform cameraPos1;
    public Transform cameraPos2;
    public Transform cameraPos3;

    private float _speed = 1.2f;

    //identificar numero da c�mera
    //objeto que � o objetivo
    private int _currentCamera;
    private Transform _cameraTarget;

    public Text sceneText;

    void Start()
    {
        _currentCamera = 1;
        SetCameraTarget(_currentCamera);
    }

    //no update eu s� tenho as transforma��es, quem controla qual � a camera � o SetCameraTarget
    //Time.deltaTime pra garantir const�ncia independente dos FPS
    void Update()
    {
        Vector3 tPos = _cameraTarget.position;
        Vector3 cPos = Vector3.Lerp(transform.position, tPos, Time.deltaTime * _speed);

        transform.position = cPos;

        Vector3 tAng = _cameraTarget.transform.rotation.eulerAngles;
        Vector3 cAng = new Vector3(
            Mathf.Lerp(transform.rotation.eulerAngles.x, tAng.x, Time.deltaTime * _speed),
            Mathf.Lerp(transform.rotation.eulerAngles.y, tAng.y, Time.deltaTime * _speed),
            Mathf.Lerp(transform.rotation.eulerAngles.z, tAng.z, Time.deltaTime * _speed)
            );

        transform.eulerAngles = cAng;

        sceneText.text = $"{_currentCamera}";
    }

    /// <summary>
    /// m�todo que iguala o cameraTarget ao objeto da posi��o desejada (l� na unity)
    /// </summary>
    /// <param name="num"></param>
    public void SetCameraTarget(int num)
    {
        switch (num)
        {
            case 1:
                _cameraTarget = cameraPos1.transform;
                break;
            case 2:
                _cameraTarget = cameraPos2.transform;
                break;
            case 3:
                _cameraTarget = cameraPos3.transform;
                break;
        }
    }

    //m�todos inseridos no OnClick() dos bot�es
    public void AdvanceCamera()
    {
        if (_currentCamera < 3) { _currentCamera++; }
        else { _currentCamera = 1; }
        SetCameraTarget(_currentCamera);
    }

    public void BackCamera()
    {
        if (_currentCamera < 2) { _currentCamera = 3; }
        else { _currentCamera--; }
        SetCameraTarget(_currentCamera);
    }
}
