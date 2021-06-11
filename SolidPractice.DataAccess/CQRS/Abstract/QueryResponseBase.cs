namespace SolidPractice.DataAccess.CQRS.EntityFramework.Queries.Response
{
    public abstract class QueryResponseBase
    {
        public bool IsSuccess { get; set; }


        public QueryResponseBase()
        {
            this.IsSuccess = true;
        }


        public QueryResponseBase(bool isSuccess)
        {
            this.IsSuccess = isSuccess;
        }
    }
}