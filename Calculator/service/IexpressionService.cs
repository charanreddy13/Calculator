

using Calculator.Model;

namespace Calculator.service
{
    public interface IexpressionService
    {
        Task<List<Expression>> GetExpressions();

        Task<int> AddExpression(Expression expression);

        Task<int> DeleteExpression(Expression expression);
    }
}
