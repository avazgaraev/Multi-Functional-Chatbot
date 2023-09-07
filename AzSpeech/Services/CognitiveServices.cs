using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;

namespace AzSpeech.Services
{
    public class CognitiveServices : ICognitiveServices
    {
        const string speechKey = "";
        const string speechRegion = "eastus";

        public async void GetSpeech()
        {
            var speechConfig = SpeechConfig.FromSubscription(speechKey, speechRegion);

            // The language of the voice that speaks.
            speechConfig.SpeechSynthesisVoiceName = "az-AZ-BabekNeural";

            using (var speechSynthesizer = new SpeechSynthesizer(speechConfig))
            {
                string text = "Salam, mənim adım Babəkdir.";

                var speechSynthesisResult = await speechSynthesizer.SpeakTextAsync(text);
                OutputSpeechSynthesisResult(speechSynthesisResult, text);
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        public void OutputSpeechSynthesisResult(SpeechSynthesisResult speechSynthesisResult, string text)
        {
            switch (speechSynthesisResult.Reason)
            {
                case ResultReason.SynthesizingAudioCompleted:
                    Console.WriteLine($"Speech synthesized for text: [{text}]");
                    break;
                case ResultReason.Canceled:
                    var cancellation = SpeechSynthesisCancellationDetails.FromResult(speechSynthesisResult);
                    Console.WriteLine($"CANCELED: Reason={cancellation.Reason}");

                    if (cancellation.Reason == CancellationReason.Error)
                    {
                        Console.WriteLine($"CANCELED: ErrorCode={cancellation.ErrorCode}");
                        Console.WriteLine($"CANCELED: ErrorDetails=[{cancellation.ErrorDetails}]");
                        Console.WriteLine($"CANCELED: Did you set the speech resource key and region values?");
                    }
                    break;
                default:
                    break;
            }
        }


    }
}
