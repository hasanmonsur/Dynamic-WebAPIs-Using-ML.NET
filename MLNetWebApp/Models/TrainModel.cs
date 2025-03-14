using Microsoft.ML;

namespace MLNetWebApp.Models
{
    public class TrainModels
    {
        public static ITransformer TrainModel(MLContext mlContext, IDataView data)
        {
            var pipeline = mlContext.Transforms.Concatenate("Features", new[] { "Feature1", "Feature2" })
                .Append(mlContext.BinaryClassification.Trainers.LbfgsLogisticRegression());

            return pipeline.Fit(data);
        }
    }
}
