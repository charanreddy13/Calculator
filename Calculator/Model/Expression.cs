using SQLite;


namespace Calculator.Model
{
    [Table("Expressions")]
    public class Expression
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string expression { get; set; }

        public int result { get; set; }

    }
}
