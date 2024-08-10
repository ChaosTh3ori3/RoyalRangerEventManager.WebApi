namespace RangerEventManager.WebApi.Exceptions.Camp
{
    public class MemberAlreadyExistsException : Exception
    {
        public MemberAlreadyExistsException(long campNumber, string memberUserName) 
            : base($"The member {memberUserName} already exists in the camp {campNumber}") 
        { }
    }
}
