
using KokoroServerContracts;
using KokoroSharp;
using KokoroSharp.Core;
using ServiceWire;
using ServiceWire.NamedPipes;

var logger = new Logger(logLevel: LogLevel.Debug);
var stats = new Stats();
 
var pipeName = "ServiceWireTestHost";
 
var kServer = new KServer();
 
var nphost = new NpHost(pipeName, logger, stats);
nphost.AddService<IKokoroServer>(kServer);
 
nphost.Open();
 
Console.WriteLine("Press Enter to stop the dual host test.");
Console.ReadLine();
 
nphost.Close();
 
Console.WriteLine("Press Enter to quit.");
Console.ReadLine();

class KServer : IKokoroServer
{
    private readonly KokoroTTS _tts;
    private readonly KokoroVoice _voice;

    public KServer()
    {
        Console.WriteLine("Initializing Kokoro Server...");
        _tts = KokoroTTS.LoadModel(); // Load or download the model (~320MB for full precision)
        KokoroVoiceManager.LoadVoicesFromPath(Path.Combine(Environment.CurrentDirectory, "voices"));
        _voice = KokoroVoiceManager.GetVoice("af_nicole"); // Grab a voice of your liking,
        Console.WriteLine("Ready to play TTS...");
        Console.WriteLine();

    }
    
    public TestResponse PlayTTS(string textToPlay)
    {
        var handle = _tts.SpeakFast(textToPlay, _voice);

        Console.WriteLine($"Received and played: {textToPlay}");
        return new TestResponse
        {
            Id = Guid.NewGuid(),
        };
    }
}

// logger and stats are optional 
// there is a null implementation by default