using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndividualCyliderScript : MonoBehaviour
{
    public int _band;
    public float _startScale, _scaleMultipler;
    public bool _useBuffer;
	void Start () {
		
	}
	
	void Update () {
	    if (_useBuffer)
	    {
	        transform.localScale = new Vector3(transform.localScale.x,
	            (AudioVisualization._bandBuffer[_band] * _scaleMultipler) + _startScale, transform.localScale.z);
        }
	    else
	    {
	        transform.localScale = new Vector3(transform.localScale.x,
	            (AudioVisualization._freqBand[_band] * _scaleMultipler) + _startScale, transform.localScale.z);
        }
		
	}
}
