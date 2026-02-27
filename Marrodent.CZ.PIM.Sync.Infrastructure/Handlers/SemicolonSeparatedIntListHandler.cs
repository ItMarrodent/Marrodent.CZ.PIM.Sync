using System.Data;
using Dapper;

namespace Marrodent.CZ.PIM.Sync.Infrastructure.Handlers
{
    public class SemicolonSeparatedIntListHandler : SqlMapper.TypeHandler<ICollection<int>>
    {
        public override void SetValue(IDbDataParameter parameter, ICollection<int> value)
        {
            parameter.Value = value != null ? string.Join(";", value) : null;
        }

        public override List<int> Parse(object value)
        {
            if (value == null || value == DBNull.Value)
                return new List<int>();

            string str = value.ToString();
            if (string.IsNullOrWhiteSpace(str))
                return new List<int>();

            return str.Split(';', StringSplitOptions.RemoveEmptyEntries)
                .Select(s => int.Parse(s.Trim()))
                .ToList();
        }
    }
}
