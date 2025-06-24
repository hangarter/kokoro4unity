using System;
using KokoroServerContracts;
using NaughtyAttributes;
using ServiceWire.NamedPipes;
using UnityEngine;
using UnityEngine.Serialization;

public class KokoroSpeaker : MonoBehaviour
{
    [TextArea]
    [ResizableTextArea]
    [SerializeField] private string textToSpeak;

    [Button]
    private void PlayTTS()
    {
        var pipeName = "ServiceWireTestHost";

        using (var client = new NpClient<IKokoroServer>(new NpEndPoint(pipeName)))
        {
            client.Proxy.PlayTTS(textToSpeak);
        }
    }
}
