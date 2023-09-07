using Microsoft.CognitiveServices.Speech;

namespace AzSpeech.Services
{
    public interface ICognitiveServices
    {
        void OutputSpeechSynthesisResult(SpeechSynthesisResult speechSynthesisResult, string text);
        void GetSpeech();
        
    }
}
