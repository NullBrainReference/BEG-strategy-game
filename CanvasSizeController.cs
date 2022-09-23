using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasSizeController : MonoBehaviour
{
    [SerializeField] private GameObject unitsPanel;
    [SerializeField] private GameObject unitsContent;
    [SerializeField] private GameObject regionsPanel;
    [SerializeField] private GameObject buttonsPanel;
    // Start is called before the first frame update
    void Start()
    {
        //ResizeUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void ResizeUI()
    {
        VerticalLayoutGroup vertical = unitsPanel.GetComponentInParent<VerticalLayoutGroup>();
        float height = vertical.minHeight;
        unitsContent.GetComponent<GridLayoutGroup>().cellSize = new Vector2(height, height);
        regionsPanel.GetComponent<RectTransform>().offsetMax.Set(0, height);
    }
}
