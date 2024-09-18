namespace ContainerManagement.Model
{
    public class ContainerMaintenancePrediction
    {
        [ColumnName("PredictedLabel")]
        public bool RequiresMaintenance { get; set; }
    }
}
