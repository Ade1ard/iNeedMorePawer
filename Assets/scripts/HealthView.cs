using UnityEngine;
using TMPro;
using System.Collections;

public class HealthView : MonoBehaviour
{
    [SerializeField] private float _smoothDecreaseDuration = 0.5f;
    [SerializeField] private Health _health;
    [SerializeField] private TextMeshProUGUI _HealthText;
    [SerializeField] private Color _damageHealthColor;
    [SerializeField] private AnimationCurve _colorBehavior;
    [SerializeField] private Animator _healthAnimator;
    [SerializeField] private AnimationClip _healthPulseAnimation;

    private Color _originalHealthColor;

    private void Start()
    {
        _originalHealthColor = _HealthText.color;
        _HealthText.text = _health.MaxHealth.ToString("");
    }

    private void OnEnable()
    {
        _health.Changed += TakeDamage;
    }

    private void OnDisable()
    {
        _health.Changed -= TakeDamage;
    }

    private void TakeDamage(float currentHealth)
    {
        //_healthAnimator.Play(_healthPulseAnimation.name);
        StartCoroutine(DecreaseHealthSmoothly(currentHealth));
    }

    private IEnumerator DecreaseHealthSmoothly(float target)
    {
        float elapsedTime = 0f;
        float previousValue = float.Parse(_HealthText.text);

        while (elapsedTime < _smoothDecreaseDuration)
        {
            elapsedTime += Time.deltaTime;
            float normalizedPosition = elapsedTime / _smoothDecreaseDuration;
            float intermediateValue = Mathf.Lerp(previousValue, target, normalizedPosition);
            int TryValue = (int)intermediateValue;
            _HealthText.text = TryValue.ToString("");

            _HealthText.color = Color.Lerp(_originalHealthColor, _damageHealthColor, _colorBehavior.Evaluate(normalizedPosition));

            yield return null;
        }
    }
}
