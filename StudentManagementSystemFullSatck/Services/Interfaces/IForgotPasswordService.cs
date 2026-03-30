namespace StudentManagementSystemFullStack.Services.Interfaces
{
    public interface IForgotPasswordService
    {

        public Task ForgotPasswordAsync(String email);
        
        
    }
}
