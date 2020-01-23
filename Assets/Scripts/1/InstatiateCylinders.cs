using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstatiateCylinders : MonoBehaviour
{
    public GameObject _sampleCubePrefab;
    GameObject[] _sampleCube = new GameObject[512];
    public float _maxScale;
    private bool _started;

    IEnumerator Start()
    {
        for (int i = 0; i < _sampleCube.Length; i++)
        {
            GameObject _instanceSampleCube = Instantiate(_sampleCubePrefab);
            _instanceSampleCube.transform.position = transform.position;
            _instanceSampleCube.transform.parent = transform;
            _instanceSampleCube.name = "SampleCube" + i;
            transform.eulerAngles = new Vector3(0, (float)-360 / _sampleCube.Length * i, 0);
            _instanceSampleCube.transform.position = Vector3.forward * 100;
            _sampleCube[i] = _instanceSampleCube;
            yield return new WaitForSeconds(0.01f);
        }

        FindObjectOfType<AudioVisualization>().enabled = true;
        _started = true;
    }

    void Update()
    {
        if(!_started)
            return;
        for (int i = 0; i < _sampleCube.Length; i++)
        {
            if (_sampleCube != null)
            {
                _sampleCube[i].transform.localScale = new Vector3(transform.localScale.x, AudioVisualization._samples[i] * _maxScale + 2, transform.localScale.x);
            }
        }
    }
}
