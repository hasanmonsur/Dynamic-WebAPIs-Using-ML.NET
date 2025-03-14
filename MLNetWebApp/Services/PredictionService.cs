using Microsoft.ML;
using MLNetWebApp.Models;

namespace MLNetWebApp.Services
{
    public class PredictionService
    {
        private readonly PredictionEngine<ModelInput, ModelOutput> _predictionEngine;

        public PredictionService(IWebHostEnvironment env)
        {
            var mlContext = new MLContext();
            var modelPath = Path.Combine(env.ContentRootPath, "model.zip");
            if (!File.Exists(modelPath))
            {
                throw new FileNotFoundException($"Model file not found at: {modelPath}");
            }
            var model = mlContext.Model.Load(modelPath, out var modelSchema);
            _predictionEngine = mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(model);
        }

       public (bool PredictedLabel, float Score) Predict(ModelInput input)
        {
            var prediction = _predictionEngine.Predict(input);
            return (prediction.PredictedLabel, prediction.Score);
        }
    }
}
