using System.Collections;
using System.Collections.Generic;
using DigitalRuby.LightningBolt;
using UnityEngine;

public class IndividualBoltScript : MonoBehaviour {

    public int _band;
    public bool _useBuffer;
    [Range(0,1)]
    public float _startScale;
    public GameObject _endPoint;
    public bool _boltFromTop;
    private LightningBoltScript _boltScript;

    void Start()
    {
        _boltScript = GetComponent<LightningBoltScript>();
    }

    void Update()
    {
        var band = (_useBuffer ? AudioVisualization._audioBandBuffer[_band] : AudioVisualization._audioBand[_band]);
        var position = _endPoint.transform.position;
        if(!_boltFromTop)
            position.y = band * _endPoint.transform.position.y;
        _boltScript.EndPosition = position;
        _boltScript.ManualMode = _startScale > band;
    }
}
