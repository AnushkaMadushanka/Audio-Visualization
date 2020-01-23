using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntensityMultiplier : MonoBehaviour
{

    public int _band;
    public float _startScale, _scaleMultipler;
    public bool _useBuffer;
    private Light light;
    void Start()
    {
        light = GetComponent<Light>();
    }

    void Update()
    {
        light.intensity = ((_useBuffer
                               ? AudioVisualization._bandBuffer[_band]
                               : AudioVisualization._freqBand[_band]) * _scaleMultipler) + _startScale;
    }
}
