using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderFollowHead : MonoBehaviour
{
    public Transform _head;
    public Transform _Feet;
    public GameObject _followCam;
    public float _hight;

    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        _hight = _head.position.y - _Feet.position.y;
        float halfHight = _hight / 2;
        gameObject.GetComponent<CapsuleCollider>().center = new Vector3(_head.localPosition.x, _Feet.localPosition.y + halfHight, _head.localPosition.z);
        gameObject.GetComponent<CapsuleCollider>().height = _hight;
        _followCam.transform.localPosition = new Vector3(_head.localPosition.x, _Feet.localPosition.y + halfHight, _head.localPosition.z);
        _followCam.transform.localRotation = Quaternion.Euler(_Feet.rotation.x, _head.rotation.y, _Feet.rotation.y);
    }

}
