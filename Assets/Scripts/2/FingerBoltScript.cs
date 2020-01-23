using System.Collections;
using System.Collections.Generic;
using DigitalRuby.LightningBolt;
using UnityEngine;

public class FingerBoltScript : MonoBehaviour
{
    public int _band;
    public GameObject finger;
    public GameObject endPosition;
    public bool useBuffer;
    public float startScale;
    public float endRadius;
    public GameObject sparkPrefab;

    private LightningBoltScript _lightningBoltScript;
    private ParticleSystem currentSpark;

    private void Start()
    {
        _lightningBoltScript = GetComponent<LightningBoltScript>();
        _lightningBoltScript.StartObject = finger;
        _lightningBoltScript.ManualMode = false;
        currentSpark = Instantiate(sparkPrefab, Vector3.zero, Quaternion.Euler(-90, 0, 0)).GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        var band = (useBuffer ? AudioVisualization._bandBuffer[_band] : AudioVisualization._freqBand[_band]);
        _lightningBoltScript.ManualMode = startScale > band;
        if(startScale > band)
            currentSpark.Stop();
        else
            currentSpark.Play();
        var randomCirclePos = Random.insideUnitCircle * endRadius;
        var endPos = endPosition.transform.position + new Vector3(randomCirclePos.x, 0, randomCirclePos.y);
        _lightningBoltScript.EndPosition = currentSpark.transform.position = endPos;
    }
}
