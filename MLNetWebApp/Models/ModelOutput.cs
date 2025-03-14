using Microsoft.ML.Data;

namespace MLNetWebApp.Models
{
    public class ModelOutput
    {
        [ColumnName("PredictedLabel")]
        public bool PredictedLabel { get; set; }

        [ColumnName("Score")]
        public float Score { get; set; }
    }
}
