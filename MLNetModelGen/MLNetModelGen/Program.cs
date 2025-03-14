using Microsoft.ML;
using MLNetModelGen.Models;

namespace MLNetModelGen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Initialize MLContext
            var mlContext = new MLContext(seed: 0);

            // Sample data (replace with your real dataset)
            var dataPath = "data.csv"; // Path to your training data
            if (!File.Exists(dataPath))
            {
                CreateSampleData(dataPath);
            }

            // Load data
            var data = mlContext.Data.LoadFromTextFile<ModelInput>(
                path: dataPath,
                hasHeader: true,
                separatorChar: ','
            );

            // Define the pipeline
            var pipeline = mlContext.Transforms.Concatenate("Features", nameof(ModelInput.Feature1), nameof(ModelInput.Feature2))
                .Append(mlContext.BinaryClassification.Trainers.SdcaLogisticRegression(labelColumnName: "Label", featureColumnName: "Features"));

            // Train the model
            Console.WriteLine("Training the model...");
            var model = pipeline.Fit(data);

            // Save the model to model.zip
            mlContext.Model.Save(model, data.Schema, "model.zip");
            Console.WriteLine("Model saved as model.zip");
        }

        // Helper method to create sample data
        static void CreateSampleData(string path)
        {
            var sampleData = "Feature1,Feature2,Label\n1.0,2.0,true\n3.0,4.0,false\n5.0,6.0,true";
            File.WriteAllText(path, sampleData);
            Console.WriteLine("Sample data created at " + path);
        }
    }
}
