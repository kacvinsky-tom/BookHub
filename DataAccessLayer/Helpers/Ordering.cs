using System.Linq.Expressions;

namespace Core.Helpers;

public class Ordering<T>
    where T : class
{
    public Expression<Func<T, IComparable>> Expression { get; set; } = null!;
    public bool Reverse { get; set; } = false;
}
