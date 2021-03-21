using UnityEngine;
using UnityEngine.Playables;
using TMPro;

public class SubtitleTrackMixer : PlayableBehaviour
{
    private Color uiColor;

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        TextMeshProUGUI text = playerData as TextMeshProUGUI;
        string currentText = "";
        float currentAlha = 0.0f;

        if (!text) { return; }

        int inputCount = playable.GetInputCount();
        for(int i = 0; i < inputCount; i++)
        {
            float inputWeight = playable.GetInputWeight(i);

            if(inputWeight > 0)
            {
                ScriptPlayable<SubtitleBehaviour> inputPlayable = (ScriptPlayable<SubtitleBehaviour>)playable.GetInput(i);
                SubtitleBehaviour input = inputPlayable.GetBehaviour();
                currentText = input.text;
                currentAlha = inputWeight;
            }
        }

        uiColor = text.color;
        uiColor.a = currentAlha;
        text.text = currentText;
        text.color = uiColor;
    }
}
