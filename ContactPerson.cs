namespace PostLogisticsApp
{
    // Сутність клієнта / контактної особи
    public class ContactPerson : Model
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }

        public override string ToString()
        {
            return $"[Клієнт #{Id}] ПІБ: {FullName} | Тел: {PhoneNumber} | E-mail: {EmailAddress}";
        }
    }
}
