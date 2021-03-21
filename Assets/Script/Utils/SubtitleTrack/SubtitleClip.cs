using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SubtitleClip : PlayableAsset
{
    public string text;
    private LocalizationManager localizationManager;

    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        if(localizationManager == null)
        {
            localizationManager = LocalizationManager.Instance;
        }
        var playable = ScriptPlayable<SubtitleBehaviour>.Create(graph);
        SubtitleBehaviour subtitleBehaviour = playable.GetBehaviour();
        subtitleBehaviour.text = localizationManager.GetDialogue(text);

        return playable;
    }
}
