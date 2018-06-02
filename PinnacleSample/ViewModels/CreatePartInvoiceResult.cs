namespace PinnacleSample
{
    public class CreatePartInvoiceResult
    {
        public CreatePartInvoiceResult(bool success)
        {
            Success = success;
        }

        public bool Success { get; private set; }

        public override bool Equals(object obj)
        {
            var result = false;
            var AnotherResult = obj as CreatePartInvoiceResult;
            if(obj != null)
            {
                result = this.Success == AnotherResult.Success;
            }
            return result; 
        }

        public override int GetHashCode()
        {
            var hashcode = Success.GetHashCode();
            return hashcode;
        }
    }
}
