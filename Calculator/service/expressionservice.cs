

using Calculator.Model;
using SQLite;

namespace Calculator.service
{
    public class expressionservice : IexpressionService
    {
        private SQLiteAsyncConnection _dbConnection;

        public expressionservice()
        {
            if (_dbConnection == null)
            {
                setupdb();
            }

        }
        private async void setupdb()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Expressions.db3");
            _dbConnection = new SQLiteAsyncConnection(dbPath);
            await _dbConnection.CreateTableAsync<Expression>();
        }
        public Task<int> AddExpression(Expression expression)
        {
            return _dbConnection.InsertAsync(expression);
        }



        public async Task<List<Expression>> GetExpressions()
        {
            var expressionList = await _dbConnection.Table<Expression>().ToListAsync();
            return expressionList;

        }

        public Task<int> DeleteExpression(Expression expression)
        {
            return _dbConnection?.DeleteAsync(expression);
        }
    }
}
