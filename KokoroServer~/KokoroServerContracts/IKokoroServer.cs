using System;

namespace KokoroServerContracts
{
    public interface IKokoroServer
    {
        TestResponse PlayTTS(string textToPlay);
    }

    [Serializable]
    public struct TestResponse
    {
        public Guid Id { get; set; }
    }
 
    // [Serializable]
    // public struct TestResponse
    // {
    //     public Guid Id { get; set; }
    //     public string Label { get; set; }
    //     public long Quantity { get; set; }
    // }
}