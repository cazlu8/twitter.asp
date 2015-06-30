
namespace Infrastructure
{
    public class Validator
    {
        public static void Validate(IObjectValidation obj)
        {
            obj.Validate();
        }
    }
}
