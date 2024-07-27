namespace Domain.Guards
{
    public static class CustomGuards
    {
        public static void AgainstStringNullOrEmpty(string value, string parameterName){
            if(string.IsNullOrEmpty(value)){
                throw new ArgumentException($"{parameterName} não pode ser nulo ou vazio.",parameterName);
            }
        }

        public static void AgainstStringNullOrWhiteSpace(string value, string parameterName){
            if(string.IsNullOrWhiteSpace(value)){
                throw new ArgumentException($"{parameterName} não pode ser nulo, vazio ou texto em branco.", parameterName);
            }
        }

       public static Guid AgainstInvalidGuid(string value, string paramName){
            if(Guid.TryParse(value,out Guid guid)){
                return guid;
            }
            else{
                throw new ArgumentException($"{paramName} não é um Guid válido.",paramName);
            }
        }
    }
}