using System.Collections;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _delay = 0.5f;
    [SerializeField] private TextMeshProUGUI _text;

    private Coroutine _coroutine;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _coroutine == null)
        {
            _coroutine = StartCoroutine(CountUpdate(_delay));
        }
        else if (Input.GetMouseButtonDown(0))
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    private IEnumerator CountUpdate(float delay)
    {
        var wait = new WaitForSeconds(delay);

        while (true)
        {
            DisplayCountUpdate();
            yield return wait;
        }
    }

    private void DisplayCountUpdate()
    {
        _text.text = (int.Parse(_text.text) + 1).ToString();
    }
}
