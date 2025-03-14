using Microsoft.ML.Data;

namespace MLNetWebApp.Models
{
    public class ModelInput
    {
        [ColumnName("Feature1"), LoadColumn(0)]
        public float Feature1 { get; set; }

        [ColumnName("Feature2"), LoadColumn(1)]
        public float Feature2 { get; set; }

        [ColumnName("Label"), LoadColumn(2)]
        public bool Label { get; set; }
    }
}
