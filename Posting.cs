namespace PostLogisticsApp
{
    // Сутність посилки
    public class Posting : Model
    {
        public string TrackCode { get; set; }
        public double ParcelWeight { get; set; }
        public string DepartureAddress { get; set; }
        public string DestinationAddress { get; set; }
        public string DeliveryStatus { get; set; }

        public override string ToString()
        {
            return $"[Відправлення #{Id}] Трек-код: {TrackCode}, Маса: {ParcelWeight} кг, Звідки: \"{DepartureAddress}\" -> Куди: \"{DestinationAddress}\", Стан: {DeliveryStatus}";
        }
    }
}
