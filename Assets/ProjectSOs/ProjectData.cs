using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Project Data")]
public class ProjectData : ScriptableObject
{
    [Header("text")]
    public string Name;
    public Color TitleColor;
    [TextArea(10,10)]
    public string Description;
    public Color DescriptionColor;
    [TextArea(20, 20)]
    public string Tags;
    public List<Languages> UsedLanguages;

    [Header("Links")]
    public string ProjectLink;
    public string GitHubLink;


    [Header("SlideShow")]
    public bool SlideShowActive;
    public List<Texture2D> ImageList;
    public Material SlideShow;
    public float FadeDuration;
    public float FrameDuration;
    public bool isOnTexture2;
    public int ImageIndex;


    public List<GameObject> AdditionalObjects;

    public enum Languages
    {
        HTML,
        CSS,
        JavaScript,
        Csharp,
        Cpp,
        Python,
        HLSL,
        ShaderGraph,
        VFXGraph,
    }

    public IEnumerator CycleImages()
    {
        while (SlideShowActive)
        {
            bool isAtEnd = CheckTexture("_Texture_1", "_Texture_2");
            SlideShow.SetFloat("_Progress", 0);
            while (SlideShow.GetFloat("_Progress") < 1)
            {
                SlideShow.SetFloat("_Progress", SlideShow.GetFloat("_Progress") + Time.deltaTime / FadeDuration);
                yield return null;
            }
            ImageIndex = isAtEnd ? 0 : ImageIndex + 1;
            yield return new WaitForSeconds(FrameDuration);
        }
    }
    private bool CheckTexture(string start, string end)
    {
        SlideShow.SetTexture(start, ImageList[ImageIndex]);
        if (ImageList.Count > ImageIndex + 1)
        {
            SlideShow.SetTexture(end, ImageList[ImageIndex + 1]);
            return false;
        }
        else
        {
            SlideShow.SetTexture(end, ImageList[0]);
            return true;
        }
    }
}
