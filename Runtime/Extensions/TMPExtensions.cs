using StdNounou.Core;
using TMPro;

public static class TMPExtensions
{
    public static void SetData(this TextMeshPro tmp, SO_TMPData data)
    {
        if (data == null)
        {
            CustomLogger.LogError(typeof(TMPExtensions), "TMP Data was null.");
            return;
        }

        if (data.Font != null) tmp.font = data.Font;
        tmp.fontStyle = data.FontStyles;
        tmp.fontSize = data.FontSize;

        tmp.enableVertexGradient = data.UseColorGradiant;
        tmp.colorGradientPreset = data.Gradiant;

        tmp.characterSpacing = data.CharacterSpacing;
        tmp.lineSpacing = data.LineSpacing;
        tmp.wordSpacing = data.WordSpacing;
        tmp.paragraphSpacing = data.ParagraphSpacing;

        tmp.horizontalAlignment = data.HorizontalAlignmentOptions;
        tmp.verticalAlignment = data.VerticalAlignmentOptions;
    }
}