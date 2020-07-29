using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Dropdown))]
public class ProjectileOptionSelector : MonoBehaviour
{
    public ProjectileOption[] options;
    public ProjectileOptionEvent OnProjectileOptionSelected;

    private Dropdown _dropdown;

    private void Start()
    {
        if(options.Length == 0)
        {
            return;
        }

        _dropdown = GetComponent<Dropdown>();
        _dropdown.options = options.Select(option => new Dropdown.OptionData(option.name)).ToList();
        _dropdown.onValueChanged.AddListener(index => OnProjectileOptionSelected.Invoke(options[index]));
        _dropdown.onValueChanged.Invoke(0);
    }
}
