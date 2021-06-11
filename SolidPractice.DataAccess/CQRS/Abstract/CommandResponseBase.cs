namespace SolidPractice.DataAccess.CQRS.EntityFramework.Commands.Response
{
    public abstract class CommandResponseBase
    {
        public bool IsSuccess { get; set; }


        public CommandResponseBase()
        {
            this.IsSuccess = true;
        }


        public CommandResponseBase(bool isSuccess)
        {
            this.IsSuccess = isSuccess;
        }
    }
}