using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonAnimHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
{
    [SerializeField] private float _verticalMoveAmount = 30f;
    [SerializeField] private float _moveTime = 0.1f;
    [Range(0f, 2f), SerializeField] private float _scaleAmount = 1.1f;

    private Vector3 _startPosition;
    private Vector3 _startScale;
    private Coroutine _currentCoroutine;

    private TextMeshProUGUI buttonText;
    private string originalText;


    public bool isMainMenu;
    private void Start()
    {
        _startPosition = transform.position;
        _startScale = transform.localScale;

        buttonText = GetComponentInChildren<TextMeshProUGUI>();

        originalText = buttonText.text;

    }

    private IEnumerator MoveButton(bool startAnimation)
    {
        Vector3 endPosition = startAnimation ? _startPosition + new Vector3(0f, _verticalMoveAmount, 0f) : _startPosition;
        Vector3 endScale = startAnimation ? _startScale * _scaleAmount : _startScale;

        float elapsedTime = 0f;

        while (elapsedTime < _moveTime)
        {
            elapsedTime += Time.deltaTime; // Increment elapsed time
            float t = elapsedTime / _moveTime;

            // Calculate the lerped amounts
            transform.position = Vector3.Lerp(transform.position, endPosition, t);
            transform.localScale = Vector3.Lerp(transform.localScale, endScale, t);

            yield return null;
        }

        // Ensure final position and scale are set
        transform.position = endPosition;
        transform.localScale = endScale;
    }

    public void OnSelect(BaseEventData eventData)
    {
        if (_currentCoroutine != null) StopCoroutine(_currentCoroutine);
        _currentCoroutine = StartCoroutine(MoveButton(true));
    }
        
    public void OnDeselect(BaseEventData eventData)
    {
        if (_currentCoroutine != null) StopCoroutine(_currentCoroutine);
        _currentCoroutine = StartCoroutine(MoveButton(false));
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Pointer Entered");
        // Optionally, you can trigger the animation here if desired
        if (_currentCoroutine != null) StopCoroutine(_currentCoroutine);
        _currentCoroutine = StartCoroutine(MoveButton(true));

        if (isMainMenu)
        {
            buttonText.text = ("- " + buttonText.text + " -");
        }
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Pointer Exited");
        // Optionally, you can trigger the animation here if desired
        if (_currentCoroutine != null) StopCoroutine(_currentCoroutine);
        _currentCoroutine = StartCoroutine(MoveButton(false));
        if (isMainMenu)
        {
            buttonText.text = originalText;
        }
        
    }

    private void OnDisable()
    {
        buttonText.text = originalText;
        transform.position = _startPosition;
        transform.localScale = _startScale;
    }
}