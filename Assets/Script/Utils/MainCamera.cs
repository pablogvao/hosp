using UnityEngine;
using UnityEngine.UI;

public class MainCamera : MonoBehaviour
{
    //objetos vazios das posições
    public Transform cameraPos1;
    public Transform cameraPos2;
    public Transform cameraPos3;

    private float _speed = 1.2f;

    //identificar numero da câmera
    //objeto que é o objetivo
    private int _currentCamera;
    private Transform _cameraTarget;

    public Text sceneText;

    void Start()
    {
        _currentCamera = 1;
        SetCameraTarget(_currentCamera);
    }

    //no update eu só tenho as transformações, quem controla qual é a camera é o SetCameraTarget
    //Time.deltaTime pra garantir constância independente dos FPS
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
    /// método que iguala o cameraTarget ao objeto da posição desejada (lá na unity)
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

    //métodos inseridos no OnClick() dos botões
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
