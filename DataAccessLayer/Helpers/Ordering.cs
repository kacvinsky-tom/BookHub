using System.Linq.Expressions;
using DataAccessLayer.Entity;

namespace Core.Helpers;

public class Ordering<T>
    where T : BaseEntity
{
    public Expression<Func<T, IComparable>> Expression { get; set; }
    public bool Reverse { get; set; } = false;
}
