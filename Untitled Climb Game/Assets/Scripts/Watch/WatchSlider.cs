using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WatchSlider : MonoBehaviour
{
    public GameObject _time;
    public GameObject _watchSlider;
    public Animator _watchAnimator;
    float _watchAniFloat;
    public GameObject _watchHight;

    public GameObject _quitSlider;
    public GameObject _quitButton;
    bool _quitting;

    public void QuitClimb()
    {
        _quitting = _quitButton.GetComponent<Toggle>().isOn;
    }
    void FixedUpdate()
    {
        if (_watchSlider.GetComponent<Slider>().value >= 0.5)
        {
            float tempfloatWatch = 1f;
            if(_watchAniFloat <= tempfloatWatch)
            {
                _watchAniFloat += 0.1f;
            }

        }
        if (_watchSlider.GetComponent<Slider>().value <= 0.5)
        {
            float tempfloatWatch = 0f;
            if (_watchAniFloat >= tempfloatWatch)
            {
                _watchAniFloat -= 0.1f;
            }

        }
    }
    private void Update()
    {
        float _hight = transform.position.y;
        _watchHight.GetComponent<TMP_Text>().text = new string(Mathf.Round(_hight).ToString());

        _watchAnimator.GetComponent<Animator>().SetFloat("Blend", _watchAniFloat);

        _time.GetComponent<TMP_Text>().text = new string(System.DateTime.Now.ToString("HH:mm"));

        if (_quitting)
        {
            if (_quitSlider.GetComponent<Slider>().value <= 1)
            {
                _quitSlider.GetComponent<Slider>().value += 0.1f;
            }
            if(_quitSlider.GetComponent<Slider>().value >= 1)
            {
                Debug.Log("quitting");
            }
        }
        else
        {
            _quitSlider.GetComponent<Slider>().value = 0f;
        }
    }
}
