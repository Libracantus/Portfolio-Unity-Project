using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProjectHandler : MonoBehaviour
{
    [SerializeField] private ProjectData data;

    [SerializeField] private TMP_Text name;
    [SerializeField] private TMP_Text description;
    [SerializeField] private TMP_Text tags;
    [SerializeField] private GameObject slideShowQuad;
    [SerializeField] private List<GameObject> additionalObjects;
    // Start is called before the first frame update
    void Start()
    {
        name.text = data.name;
        name.color = data.TitleColor;
        description.text = data.Description;
        description.color = data.DescriptionColor;
        additionalObjects = data.AdditionalObjects;
        StartCoroutine(data.CycleImages());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
